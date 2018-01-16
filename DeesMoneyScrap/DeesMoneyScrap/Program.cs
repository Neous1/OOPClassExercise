using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DeesMoneyScrap
{
    class Login
    {
        private readonly string _pswd;
        private readonly string _username;

        public Login(string username, string pswd)
        {
            _username = username;
            _pswd = pswd;
        }

        public void LogIn()
        {
            //login to yahoo
            Drivers.Driver.Navigate()
                .GoToUrl(
                    "https://login.yahoo.com/?.src=fpctx&.intl=us&.lang=en-US&authMechanism=primary&yid=&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&add=1");
            var username = Drivers.Driver.FindElementById("login-username");
            username.SendKeys("jayd9817");
            var nextButton = Drivers.Driver.FindElementById("login-signin");
            nextButton.Click();

            //setup wait time to make sure table is built
            //WebDriverWait wait = new WebDriverWait(Drivers.Driver, TimeSpan.FromSeconds(10));
            var pswd = Drivers.Wait.Until(d => d.FindElement(By.Id("login-passwd")));

            pswd.SendKeys("ICG9817#");
            var sign = Drivers.Driver.FindElementById("login-signin");
            sign.Click();

        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-gpu");

            // var chromeDriver = new ChromeDriver(options);

            

            //go to portfolio page
            Drivers.Driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");

            //load table
            var mytable = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));

            var rowCount = mytable.FindElements(By.XPath(".//tr")).Count; //row shortcut

            var pullTime = DateTime.Now; //Scrape time

            //loop thru the table by row
            for (int i = 1; i <= rowCount; i++)
            {
                var rowXpath = $"//tr[{i}]"; //"//tr[@data-index='0']";
                var symb = mytable.FindElement(By.XPath(rowXpath + "/td[1]/span/a"))
                    .Text; //"//a[contains(@href,'/quote/')]")).Text;
                var lastP = mytable.FindElement(By.XPath(rowXpath + "/td[2]/span"))
                    .Text; //"//span[@class='_3Bucv']")).Text;
                // var change = mytable.FindElement(By.XPath(rowXpath + "/td[3]/span")).Text; //"//span[contains(@class,'_2ZN-S')]")).Text;
                var changePerc = mytable.FindElement(By.XPath(rowXpath + "/td[4]/span")).Text;
                var volume = mytable.FindElement(By.XPath(rowXpath + "/td[7]/span")).Text;
                var volAvg = mytable.FindElement(By.XPath(rowXpath + "/td[9]")).Text;
                Console.WriteLine($"{pullTime}\t{symb}\t{lastP}\t{changePerc}\t{volume}\t{volAvg}");
                Console.WriteLine();
            }
            Drivers.Driver.Close();



        }
    }

}
