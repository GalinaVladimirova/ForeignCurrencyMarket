using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ForeignCurrencyMarket
{
    public class CurrencyRates
    {
        private FCMContext _context;

        public CurrencyRates()
        {
            _context = new FCMContext();
        }

        public class ValCurs
        {
            [XmlElement("Valute")]
            public ValCursValute[] ValuteList;
        }
        public class ValCursValute
        {
            [XmlElement("CharCode")]
            public string ValuteCharCode;

            [XmlElement("NumCode")]
            public int ValuteNumCode;

            [XmlElement("Nominal")]
            public int Nominal;

            [XmlElement("Name")]
            public string ValuteName;

            [XmlElement("Value")]
            public string ExchangeRate;
        }
        

        public decimal GetExchangeRates(CurrencyCode currencyCode, DateTime date)
        {
            List<Currency> currencyList = new List<Currency>();
            XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
            XmlReader xr = new XmlTextReader(String.Format("http://www.cbr.ru/scripts/XML_daily.asp?date_req={0}", date));
            foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
            {
                currencyList.Add(new Currency()
                {
                    Name = valute.ValuteName,
                    CharCode = valute.ValuteCharCode,
                    Id = valute.ValuteNumCode,
                    Nominal = valute.Nominal,
                    Value = Convert.ToDecimal(valute.ExchangeRate),
                    Date = date
                });
            }
            var currency = currencyList.FindLast(c => c.CharCode.ToString() == currencyCode.ToString());
            _context.Currencies.Add(currency);
            _context.SaveChanges();

            return currency.Value;
        }
    }
}
