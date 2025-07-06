using MediatR;

using MiniInvest.Application.Interfaces.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Commands.FundWallet
{
    public class FundWalletCommandHandler : IRequestHandler<FundWalletCommand,Unit>
    {
        private readonly IInvestorRepository _repository;

        public FundWalletCommandHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FundWalletCommand request, CancellationToken cancellationToken)
        {
            var investor = await _repository.GetByIdAsync(request.InvestorId);
            if (investor == null) throw new Exception("Investor not found");

            investor.FundWallet(request.Amount);
            await _repository.UpdateAsync(investor);

            return Unit.Value;
        }
    }
}
