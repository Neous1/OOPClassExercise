using System;
using OpenQA.Selenium;

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
            var username = Drivers.Driver.FindElement(By.Id("login-username"));
            username.SendKeys(_username);
            var nextButton = Drivers.Driver.FindElement(By.Id("login-signin"));
            nextButton.Submit();
            //setup wait time to make sure table is built
            //WebDriverWait wait = new WebDriverWait(Drivers.Driver, TimeSpan.FromSeconds(10));
            var pswd = Drivers.Wait.Until(d => d.FindElement(By.Id("login-passwd")));

            pswd.SendKeys(_pswd);
            var sign = Drivers.Driver.FindElement(By.Id("login-signin"));
            sign.Click();
        }



    }
}