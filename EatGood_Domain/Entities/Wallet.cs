using EatGood_Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatGood_Domain.Entities
{
    public class Wallet: BaseEntity
    {
        public string WalletNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public string Reference { get; set; }
        public string PaystackCustomerCode { get; set; } = string.Empty;
        public string TransactionPin { get; set; } = string.Empty;

        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; } = string.Empty;
        public IEnumerable<WalletFunding> WalletFundings { get; set; } = new List<WalletFunding>();
    }
}
