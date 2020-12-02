using System;
using System.Collections.Generic;
using System.Linq;
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
        

        private void DownloadExchangeRates(CurrencyCode currencyCode, DateTime date)
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

        }

        private decimal GetExchangeRatesFromDb(CurrencyCode currencyCode, DateTime date)
        {
            Currency currency = _context.Currencies.FirstOrDefault(c => c.CharCode == currencyCode.ToString() && c.Date==date);
            if (currency != null)
                return currency.Value;
            else
                return -1;
        }

        public decimal GetExchangeRates(CurrencyCode currencyCode, DateTime date)
        {
            try
            {
                var c = GetExchangeRatesFromDb(currencyCode, date);
                if (c == -1)
                {
                    DownloadExchangeRates(currencyCode, date);
                    return GetExchangeRatesFromDb(currencyCode, date);
                }
                     
                else
                    return c;
            }
            catch(Exception e)
            {
                throw new Exception("При получении данных возникла ошибка: {0}", e.InnerException);
            }
            
        }
    }
}
