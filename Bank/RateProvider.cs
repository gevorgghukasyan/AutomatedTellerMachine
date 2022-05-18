using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Bank
{
    class RateProvider
    {
        public List<Rate> GetValueMoney()
        {
            List<Rate> list = new List<Rate>();

            string url = "https://www.conversebank.am/hy/exchange-rate/";
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            string USD = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[3]/td[1]")[0].InnerText;
            string valueUSD = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[3]/td[3]")[0].InnerText;
            Rate USDData = new Rate(USD, valueUSD);
            list.Add(USDData);

            string EUR = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[4]/td[1]")[0].InnerText;
            string valueEUR = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[4]/td[3]")[0].InnerText;
            Rate EURData = new Rate(EUR, valueEUR);
            list.Add(EURData);

            string RUB = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[6]/td[1]")[0].InnerText;
            string valueRUB = doc.DocumentNode.SelectNodes("//*[@id=\"main_static_content\"]/table[1]/tbody/tr[6]/td[3]")[0].InnerText;
            Rate RUBData = new Rate(RUB, valueRUB);
            list.Add(RUBData);

            return list;
        }
    }
}
