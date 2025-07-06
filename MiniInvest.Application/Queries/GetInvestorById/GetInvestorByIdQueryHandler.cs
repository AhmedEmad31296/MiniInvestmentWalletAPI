using MediatR;

using MiniInvest.Application.Interfaces.Repositories;
using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Queries.GetInvestorById
{
    public class GetInvestorByIdQueryHandler : IRequestHandler<GetInvestorByIdQuery, Investor?>
    {
        private readonly IInvestorRepository _repository;

        public GetInvestorByIdQueryHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Investor?> Handle(GetInvestorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.InvestorId);
        }
    }
}
