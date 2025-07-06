using MediatR;

using MiniInvest.Application.Interfaces.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Queries.GetWalletBalance
{
    public class GetWalletBalanceQueryHandler : IRequestHandler<GetWalletBalanceQuery, decimal>
    {
        private readonly IInvestorRepository _repository;

        public GetWalletBalanceQueryHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            var investor = await _repository.GetByIdAsync(request.InvestorId);
            if (investor == null) throw new Exception("Investor not found");
            return investor.WalletBalance;
        }
    }
}
