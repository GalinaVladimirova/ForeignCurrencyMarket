using System.Data.Entity;

namespace ForeignCurrencyMarket
{
    public class FCMContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
    }
}
