using MediatR;

using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Queries.GetInvestmentHistory
{
    public record GetInvestmentHistoryQuery(Guid InvestorId) : IRequest<List<Investment>>;
}
