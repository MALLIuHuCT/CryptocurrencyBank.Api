using CryptocurrencyBank.Application.Abstractions.Commands;
using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Application.MoneyTransfers.Create;
using CryptocurrencyBank.Application.MoneyTransfers.Delete;
using CryptocurrencyBank.Application.MoneyTransfers.Requests;
using CryptocurrencyBank.Application.MoneyTransfers.Update;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Repositories;

namespace CryptocurrencyBank.Application.MoneyTransfers
{
    public class MoneyTransferService : ICommandHandler<MoneyTransferCreateCommand>,
        ICommandHandler<MoneyTransferDeleteCommand>,
        ICommandHandler<MoneyTransferUpdateCommand>,
        IRequestHandler<MoneyTransferGetAllRequest, IEnumerable<MoneyTransfer>>,
        IRequestHandler<MoneyTransferGetByIdRequest, MoneyTransfer>,
        IRequestHandler<MoneyTransferGetAllByDateRequest, IEnumerable<MoneyTransfer>>
    {
        private readonly IMoneyTransferRepository _moneyTransferRepository;
        private readonly IBalanceRepository _balanceRepository;

        public MoneyTransferService(IMoneyTransferRepository moneyTransferRepository, IBalanceRepository balanceRepository)
            => (_moneyTransferRepository, _balanceRepository) = (moneyTransferRepository, balanceRepository);

        public async Task HandleAsync(MoneyTransferCreateCommand command, CancellationToken token)
        {
            var created = _moneyTransferRepository.CreateNew(command.From, command.To, command.HowMany, command.Date, command.TransferType, command.Client, token);
            
            var from = await _balanceRepository.GetByIdAsync(command.From, token);
            var to = await _balanceRepository.GetByIdAsync(command.To, token);

            from.Subtract(command.HowMany);
            to.Add(command.HowMany);
            
            await _moneyTransferRepository.Insert(created, token);
            await _moneyTransferRepository.SaveAsync();
        }

        public async Task HandleAsync(MoneyTransferDeleteCommand command, CancellationToken token)
        {
            var transfer = await _moneyTransferRepository.GetByIdAsync(command.Id, token) ?? throw new Exception("Transfer not founded");

            var balanceFrom = await _balanceRepository.GetByIdAsync(transfer.From, token);
            var balanceTo = await _balanceRepository.GetByIdAsync(transfer.To, token);

            balanceFrom.Add(transfer.HowMany);
            balanceTo.Subtract(transfer.HowMany);

            await _moneyTransferRepository.DeleteAsync(command.Id, token);
        }

        public async Task HandleAsync(MoneyTransferUpdateCommand command, CancellationToken token)
        {
            var transfer = await _moneyTransferRepository.GetByIdAsync(command.Id, token) ?? throw new Exception("Transfer not founded");
            var balanceFrom = await _balanceRepository.GetByIdAsync(command.From, token) ?? throw new Exception("Not founded balance");
            var balanceTo = await _balanceRepository.GetByIdAsync(command.To, token) ?? throw new Exception("Not founded balance");

            var balanceToPrevious = await _balanceRepository.GetByIdAsync(command.Id, token);
            balanceToPrevious.Subtract(transfer.HowMany);
            balanceTo.Add(command.HowMany);

            var balanceFromPrevious = await _balanceRepository.GetByIdAsync(transfer.From, token);
            balanceFromPrevious.Add(transfer.HowMany);
            balanceFrom.Subtract(command.HowMany);

            transfer.ChangeData(command.From, command.To, command.HowMany, command.Date, command.TransferType, command.Client);
            await _moneyTransferRepository.SaveAsync();
        }

        public async Task<IEnumerable<MoneyTransfer>> HandleAsync(MoneyTransferGetAllRequest request, CancellationToken token)
        {
            return await _moneyTransferRepository.GetAllAsync(token);
        }

        public async Task<MoneyTransfer> HandleAsync(MoneyTransferGetByIdRequest request, CancellationToken token)
        {
            return await _moneyTransferRepository.GetByIdAsync(request.Id, token);
        }

        public async Task<IEnumerable<MoneyTransfer>> HandleAsync(MoneyTransferGetAllByDateRequest request, CancellationToken token)
        {
            var transfers = await _moneyTransferRepository.GetAllAsync(token);
            return transfers.AsParallel().Where(x => x.Date.Date == request.Date.Date) ?? throw new Exception("Transfers not founded");
        }
    }
}
