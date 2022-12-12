using CryptocurrencyBank.Application.Balances;
using CryptocurrencyBank.Application.Balances.Requests;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Repositories;
using Moq;

namespace CryptocurrencyBank.Application.Tests
{
    public class BalanceServiceTests
    {
        private readonly Mock<IBalanceRepository> _balanceRepositoryMock;
        private readonly BalanceService _balanceService;

        public BalanceServiceTests()
        {
            _balanceRepositoryMock = new Mock<IBalanceRepository>();
            _balanceService = new BalanceService(_balanceRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnsBalances_WhenExists()
        {
            IEnumerable<Balance> balances = new[]
            {
                Balance.Create(0, null),
                Balance.Create(1, null),
                Balance.Create(2, null),
                Balance.Create(3, null)
            }.ToList();

            _balanceRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(balances);

            var items = await _balanceService.HandleAsync(new BalanceGetAllRequest(), new CancellationToken());
            Assert.NotNull(items);
        }

        [Fact]
        public async Task GetAll_ShouldReturnsNothing_WhenNotExist()
        {
            IEnumerable<Balance> balances = null;

            _balanceRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(balances);

            var items = await _balanceService.HandleAsync(new BalanceGetAllRequest(), new CancellationToken());
            Assert.Null(items);
        }

        [Fact]
        public async Task GetById_ShouldReturnsBalance_WhenExists()
        {
            IEnumerable<Balance> balances = new[]
            {
                Balance.Create(0, null),
                Balance.Create(1, null),
                Balance.Create(2, null),
                Balance.Create(3, null)
            }.ToList();

            var id = balances.First().Id;

            _balanceRepositoryMock.Setup(x => x.GetByIdAsync(id, new CancellationToken()))
                .ReturnsAsync(balances.First());

            var items = await _balanceService.HandleAsync(new BalanceGetByIdRequest(id), new CancellationToken());
            Assert.NotNull(items);
        }

        [Fact]
        public async Task GetById_ShouldReturnsNothing_WhenNotExist()
        {
            IEnumerable<Balance> balances = null;
            Balance nullAsReturn = null;

            _balanceRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), new CancellationToken()))
                .ReturnsAsync(() => null);

            var items = await _balanceService.HandleAsync(new BalanceGetByIdRequest(Guid.Empty), new CancellationToken());
            Assert.Null(items);
        }
    }
}
