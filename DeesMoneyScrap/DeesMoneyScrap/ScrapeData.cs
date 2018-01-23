using System;
using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace DeesMoneyScrap
{
    public class ScrapeData
    {
        private static readonly IWebDriver Driver = Drivers.Driver;
        private static IWebElement GetTable ()
        {
            // var chromeDriver = new ChromeDriver(options);

            var logMeIn = new Login("jayd9817", "ICG9817#");
            logMeIn.LogIn();

            //go to portfolio page
            Driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");
            
            //load table
            var mytable = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));
            return mytable;
        }

        public static void StartScrapper()
        {
            //put login her too
            var newTable = GetTable();

            var rowCount = newTable.FindElements(By.XPath(".//tr")).Count;
            var pullTime = DateTime.Now;// scrape time;

            using (var db = new MyScrapeDbContext())
            {            //loop thru the table by row
                for (int i = 1; i <= rowCount; i++)
                {
                    var rowXpath = $"//tr[{i}]"; //"//tr[@data-index='0']";
                    var symb = Driver.FindElement(By.XPath(rowXpath + "/td[1]/span/a"))
                        .Text.ToString();
                    var lastP = Driver.FindElement(By.XPath(rowXpath + "/td[2]/span"))
                        .Text;
                    var changePerc = Driver.FindElement(By.XPath(rowXpath + "/td[4]/span")).Text;
                    var volume = Driver.FindElement(By.XPath(rowXpath + "/td[7]/span")).Text;
                    var volAvg = Driver.FindElement(By.XPath(rowXpath + "/td[9]")).Text;
                    Console.WriteLine($"{pullTime}\t{symb}\t{lastP}\t{changePerc}\t{volume}\t{volAvg}");
                    Console.WriteLine();

                    var anotherTable = new ScrapeTable
                    {
                        PullTime = pullTime,
                        Symbol = symb,
                        LastPrice = lastP,
                        ChangePerc = changePerc,
                        Volume = volume,
                        VolumeAvg = volAvg
                    };

                    db.ScrapeTables.Add(anotherTable);
                    
                }
                db.SaveChanges();

                //Console.ReadLine();
            }

            Drivers.Driver.Close();
        }


        
    }
}