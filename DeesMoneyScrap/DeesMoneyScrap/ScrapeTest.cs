using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DeesMoneyScrap
{
    [TestFixture]
    public class ScrapeTest
    {
        [Test]
        public void testLogin()
        {
            //navigate to the url
            Drivers.Driver.Navigate()
                .GoToUrl(
                    "https://login.yahoo.com/?.src=fpctx&.intl=us&.lang=en-US&authMechanism=primary&yid=&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&add=1");

            //pass username and password 
            var logMeIn = new Login("jayd9817", "ICG9817#");
            logMeIn.LogIn();
            //Console.WriteLine("login to yahoo");

            //go to portfolio page
            Drivers.Driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");

            //load table
            var mytable = Drivers.Wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));
            //return mytable;

            // Assert.
        }

    }
}
