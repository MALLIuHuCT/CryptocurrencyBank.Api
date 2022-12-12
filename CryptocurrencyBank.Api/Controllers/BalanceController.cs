using CryptocurrencyBank.Application.Balances;
using CryptocurrencyBank.Application.Balances.Commands;
using CryptocurrencyBank.Application.Balances.Commands.Delete;
using CryptocurrencyBank.Application.Balances.Commands.Update;
using CryptocurrencyBank.Application.Balances.Requests;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyBank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BalanceController : ControllerBase
    {
        private readonly BalanceService _balanceService;

        public BalanceController(BalanceService balanceService)
            => _balanceService = balanceService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Balance>>> GetAll(CancellationToken token)
        {
            var request = new BalanceGetAllRequest();
            var balances = await _balanceService.HandleAsync(request, token);
            return Ok(balances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Balance>> Get(Guid id, CancellationToken token)
        {
            var request = new BalanceGetByIdRequest(id);
            var balance = await _balanceService.HandleAsync(request, token);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<ActionResult<Balance>> Create([FromBody] BalanceCreateCommand command, CancellationToken token)
        {
            await _balanceService.HandleAsync(command, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken token)
        {
            var command = new BalanceDeleteCommand(id);
            await _balanceService.HandleAsync(command, token);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] BalanceUpdateCommand command, CancellationToken token)
        {
            await _balanceService.HandleAsync(command, token);
            return Ok();
        }
    }
}
