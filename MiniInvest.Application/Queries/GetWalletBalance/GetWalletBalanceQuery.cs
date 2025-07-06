using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Queries.GetWalletBalance
{
    public record GetWalletBalanceQuery(Guid InvestorId) : IRequest<decimal>;
}
