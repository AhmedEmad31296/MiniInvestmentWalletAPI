using MediatR;

using Microsoft.AspNetCore.Mvc;

using MiniInvest.Application.Commands.CreateInvestor;
using MiniInvest.Application.Commands.FundWallet;
using MiniInvest.Application.Commands.Invest;
using MiniInvest.Application.Queries.GetInvestmentHistory;
using MiniInvest.Application.Queries.GetInvestorById;
using MiniInvest.Application.Queries.GetWalletBalance;

namespace MiniInvest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvestor([FromBody] CreateInvestorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("fund-wallet")]
        public async Task<IActionResult> FundWallet([FromBody] FundWalletCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("invest")]
        public async Task<IActionResult> Invest([FromBody] InvestCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{investorId}")]
        public async Task<IActionResult> GetInvestorById(Guid investorId)
        {
            var result = await _mediator.Send(new GetInvestorByIdQuery(investorId));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{investorId}/wallet-balance")]
        public async Task<IActionResult> GetWalletBalance(Guid investorId)
        {
            var result = await _mediator.Send(new GetWalletBalanceQuery(investorId));
            return Ok(result);
        }

        [HttpGet("{investorId}/history")]
        public async Task<IActionResult> GetInvestmentHistory(Guid investorId)
        {
            var result = await _mediator.Send(new GetInvestmentHistoryQuery(investorId));
            return Ok(result);
        }
    }
}
