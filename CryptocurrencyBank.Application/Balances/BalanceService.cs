using CryptocurrencyBank.Application.Abstractions.Commands;
using CryptocurrencyBank.Application.Balances.Requests;
using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Application.Balances.Commands;
using CryptocurrencyBank.Application.Balances.Commands.Delete;
using CryptocurrencyBank.Application.Balances.Commands.Update;
using CryptocurrencyBank.Domain.Repositories;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.Balances
{
    public class BalanceService : ICommandHandler<BalanceCreateCommand>,
        ICommandHandler<BalanceDeleteCommand>,
        ICommandHandler<BalanceUpdateCommand>,
        IRequestHandler<BalanceGetAllRequest, IEnumerable<Balance>>,
        IRequestHandler<BalanceGetByIdRequest, Balance>
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService(IBalanceRepository balanceRepository)
            => _balanceRepository = balanceRepository;

        public async Task HandleAsync(BalanceCreateCommand command, CancellationToken token)
        {
            var created = _balanceRepository.CreateNew(command.BalanceValue, command.Description, token);
            await _balanceRepository.Insert(created, token);
        }

        public async Task HandleAsync(BalanceDeleteCommand command, CancellationToken token)
        {
            await _balanceRepository.DeleteAsync(command.Id, token);
        }

        public async Task HandleAsync(BalanceUpdateCommand command, CancellationToken token)
        {
            var balance = await _balanceRepository.GetByIdAsync(command.Id, token) ?? throw new Exception("balance not founded");
            balance.ChangeDescription(command.Description);
            await _balanceRepository.SaveAsync();
        }

        public async Task<IEnumerable<Balance>> HandleAsync(BalanceGetAllRequest request, CancellationToken token)
        {
            return await _balanceRepository.GetAllAsync(token);
        }

        public Task<Balance> HandleAsync(BalanceGetByIdRequest request, CancellationToken token)
        {
            return _balanceRepository.GetByIdAsync(request.Id, token);
        }
    }
}
