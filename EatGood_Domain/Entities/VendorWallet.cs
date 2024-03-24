using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.Entities
{
    public class VendorWallet : BaseEntity
    {
        public string AppUserId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        public Vendor Vendor { get; set; }

    }
}
