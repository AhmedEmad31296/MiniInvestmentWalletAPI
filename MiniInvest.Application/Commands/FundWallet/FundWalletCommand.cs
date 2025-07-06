using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Commands.FundWallet
{
    public record FundWalletCommand(Guid InvestorId, decimal Amount) : IRequest<Unit>;
}
