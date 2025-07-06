using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Commands.Invest
{
    public record InvestCommand(Guid InvestorId, Guid OpportunityId, decimal Amount) : IRequest;
}
