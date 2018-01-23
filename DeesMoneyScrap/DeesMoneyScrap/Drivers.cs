using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DeesMoneyScrap
{
    public class Drivers
    {
        public static IWebDriver Driver = new ChromeDriver(SetDriverOptions());
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(120));

        private static ChromeOptions SetDriverOptions()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            return options;
        }

        //var options = new ChromeOptions();
        

    }
}