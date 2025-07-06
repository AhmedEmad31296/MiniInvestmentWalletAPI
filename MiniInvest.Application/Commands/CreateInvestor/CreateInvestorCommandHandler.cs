using MediatR;

using MiniInvest.Application.Interfaces.Repositories;
using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Commands.CreateInvestor
{
    public class CreateInvestorCommandHandler : IRequestHandler<CreateInvestorCommand, Guid>
    {
        private readonly IInvestorRepository _repository;

        public CreateInvestorCommandHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateInvestorCommand request, CancellationToken cancellationToken)
        {
            var investor = new Investor(request.Name, request.Email);
            await _repository.AddAsync(investor);
            return investor.Id;
        }
    }
}
