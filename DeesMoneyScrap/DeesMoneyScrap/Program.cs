using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DeesMoneyScrap
{
    class Program
    {
        static void Main(string[] args)
        {

            // var chromeDriver = new ChromeDriver(options);

            var logMeIn = new Login("jayd9817", "ICG9817#");
            logMeIn.LogIn();

            //go to portfolio page
            Drivers.Driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");

            //load table
            var mytable = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));

            var rowCount = mytable.FindElements(By.XPath(".//tr")).Count; //row shortcut

            var pullTime = DateTime.Now; //Scrape time
  

            using (var db = new MyScrapeDbContext())
            {            //loop thru the table by row
                for (int i = 1; i <= rowCount; i++)
                {
                    
                    var rowXpath = $"//tr[{i}]"; //"//tr[@data-index='0']";
                    var symb = mytable.FindElement(By.XPath(rowXpath + "/td[1]/span/a"))
                        .Text.ToString();
                    var lastP = mytable.FindElement(By.XPath(rowXpath + "/td[2]/span"))
                        .Text;
                    var changePerc = mytable.FindElement(By.XPath(rowXpath + "/td[4]/span")).Text;
                    var volume = mytable.FindElement(By.XPath(rowXpath + "/td[7]/span")).Text;
                    var volAvg = mytable.FindElement(By.XPath(rowXpath + "/td[9]")).Text;
                    Console.WriteLine($"{pullTime}\t{symb}\t{lastP}\t{changePerc}\t{volume}\t{volAvg}");
                    Console.WriteLine();

                    var newTable = new ScrapeTable {PullTime = pullTime,
                        Symbol = symb, LastPrice = lastP, ChangePerc = changePerc, Volume = volume, VolumeAvg = volAvg};

                    db.ScrapeTables.Add(newTable);
                    db.SaveChanges();

                }
                
                Console.ReadLine();
            }

            Drivers.Driver.Close();
        }
    }

    

}
