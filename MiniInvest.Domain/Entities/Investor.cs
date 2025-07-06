using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Domain.Entities
{
    public class Investor
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Email { get; private set; }
        public decimal WalletBalance { get; private set; } = 0m;
        public List<Investment> Investments { get; private set; } = new();

        private Investor() { }
        public Investor(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void FundWallet(decimal amount)
        {
            WalletBalance += amount;
        }

        public void Invest(decimal amount)
        {
            WalletBalance -= amount;
        }
    }

}
