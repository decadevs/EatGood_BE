using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string AppUserId { get; set; }
        public bool IsWalletActive { get; set; }
        public AppUser AppUser { get; set; }
    }
}
