using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DeesMoneyScrap
{
    public class Drivers
    {
        public static ChromeDriver Driver = new ChromeDriver();
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

    }
}