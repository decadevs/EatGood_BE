using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.Entities
{
    public class CustomerWallet : BaseEntity
    {
        public string CustomerId { get; set; }
        public decimal Balance { get; set; }
        public bool? IsActive { get; set; }
        public string? AccountName { get; set; }
        public Customer? Customer { get; set; }
        public string? AccountNumber { get; set; }
    }
}
