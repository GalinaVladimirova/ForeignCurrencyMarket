using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForeignCurrencyMarket.CurrencyRates;

namespace ForeignCurrencyMarket
{
    public class Currency
    {
        public int Id { get; set; }

        public string CharCode { get; set; }

        public  int Nominal { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

    }
}
