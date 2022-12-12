using CryptocurrencyBank.Application.MoneyTransfers;
using CryptocurrencyBank.Application.MoneyTransfers.Create;
using CryptocurrencyBank.Application.MoneyTransfers.Delete;
using CryptocurrencyBank.Application.MoneyTransfers.Requests;
using CryptocurrencyBank.Application.MoneyTransfers.Update;
using CryptocurrencyBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyBank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MoneyTransferController : ControllerBase
    {
        private readonly MoneyTransferService _moneyTransferService;

        public MoneyTransferController(MoneyTransferService moneyTransferService)
            => _moneyTransferService = moneyTransferService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyTransfer>>> GetAll(CancellationToken token)
        {
            var request = new MoneyTransferGetAllRequest();
            return Ok(await _moneyTransferService.HandleAsync(request, token));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyTransfer>> Get(Guid id, CancellationToken token)
        {
            var request = new MoneyTransferGetByIdRequest(id);
            return Ok(await _moneyTransferService.HandleAsync(request, token));
        }

        [HttpGet("{Date}")]
        public async Task<ActionResult<IEnumerable<MoneyTransfer>>> GetByDate(DateTime date, CancellationToken token)
        {
            var request = new MoneyTransferGetAllByDateRequest(date);
            return Ok(await _moneyTransferService.HandleAsync(request, token));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MoneyTransferCreateCommand command, CancellationToken token)
        {
            await _moneyTransferService.HandleAsync(command, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] MoneyTransferDeleteCommand command, CancellationToken token)
        {
            await _moneyTransferService.HandleAsync(command, token);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] MoneyTransferUpdateCommand command, CancellationToken token)
        {
            await _moneyTransferService.HandleAsync(command, token);
            return Ok();
        }
    }
}
