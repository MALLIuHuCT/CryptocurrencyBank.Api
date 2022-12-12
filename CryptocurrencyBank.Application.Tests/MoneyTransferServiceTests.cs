using CryptocurrencyBank.Application.Balances;
using CryptocurrencyBank.Application.Balances.Requests;
using CryptocurrencyBank.Application.MoneyTransfers;
using CryptocurrencyBank.Application.MoneyTransfers.Requests;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Repositories;
using Moq;

namespace CryptocurrencyBank.Application.Tests
{ 
    public class MoneyTransferServiceTests
    {
        private readonly MoneyTransferService _moneyTransferService;
        private readonly Mock<IBalanceRepository> _balanceRepositoryMock;
        private readonly Mock<IMoneyTransferRepository> _moneyTransferRepository;

        public MoneyTransferServiceTests()
        {
            _balanceRepositoryMock = new Mock<IBalanceRepository>();
            _moneyTransferRepository = new Mock<IMoneyTransferRepository>();
            _moneyTransferService = new MoneyTransferService(_moneyTransferRepository.Object, _balanceRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnTransfers_WhenExists()
        {
            IEnumerable<MoneyTransfer> transfers = new[]
            {
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0)
            };

            _moneyTransferRepository.Setup(x => x.GetAllAsync(new CancellationToken()))
                .ReturnsAsync(transfers);

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetAllRequest(), new CancellationToken());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNothing_WhenNotExist()
        {
            IEnumerable<MoneyTransfer> transfers = null;

            _moneyTransferRepository.Setup(x => x.GetAllAsync(new CancellationToken()))
                .ReturnsAsync(() => null);

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetAllRequest(), new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnTransfer_WhenExists()
        {
            IEnumerable<MoneyTransfer> transfers = new[]
            {
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0)
            };

            _moneyTransferRepository.Setup(x => x.GetByIdAsync(transfers.First().Id, new CancellationToken()))
                .ReturnsAsync(transfers.First());

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetByIdRequest(transfers.First().Id), new CancellationToken());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnNothing_WhenNotExist()
        {
            IEnumerable<MoneyTransfer> transfers = null;

            _moneyTransferRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), new CancellationToken()))
                .ReturnsAsync(() => null);

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetByIdRequest(Guid.Empty), new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllByDate_ShouldReturnTransfers_WhenExistsInThisDate()
        {
            IEnumerable<MoneyTransfer> transfers = new[]
            {
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today.AddDays(-1),0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today,0, 0)
            };

            _moneyTransferRepository.Setup(x => x.GetAllAsync(new CancellationToken()))
                .ReturnsAsync(transfers);

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetAllByDateRequest(DateTime.Today), new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal(transfers.Count() - 1, result.Count());
        }

        [Fact]
        public async Task GetAllByDate_ShouldReturnNothing_WhenNotExistInThisDate()
        {
            IEnumerable<MoneyTransfer> transfers = new[]
            {
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today.AddDays(1),0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today.AddDays(-1),0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today.AddDays(-1),0, 0),
                MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today.AddDays(1),0, 0)
            };

            _moneyTransferRepository.Setup(x => x.GetAllAsync(new CancellationToken()))
                .ReturnsAsync(transfers);

            var result = await _moneyTransferService.HandleAsync(new MoneyTransferGetAllByDateRequest(DateTime.Today), new CancellationToken());
            Assert.Equal(0, result.Count());
        }
    }
}
