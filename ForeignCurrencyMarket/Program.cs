using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ForeignCurrencyMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var currencyRates = new CurrencyRates();

            var currency1 = currencyRates.GetExchangeRates(CurrencyCode.JPY, new DateTime(2020,11,27));

            Console.WriteLine(currency1);
            
        }
    }
}
