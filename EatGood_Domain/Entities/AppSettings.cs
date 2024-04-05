namespace EatGood_Domain.Entities
{
    public class AppSettings
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public string AccessTokenExpiration { get; set; }
    }
}
