using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DeesMoneyScrap
{
    public class Drivers
    {
        public static ChromeDriver Driver = new ChromeDriver(SetDriverOptions());
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

        private static ChromeOptions SetDriverOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-gpu");
            //options.AddArgument("--headless");
            return options;
        }
         







        //var options = new ChromeOptions();
        

    }
}