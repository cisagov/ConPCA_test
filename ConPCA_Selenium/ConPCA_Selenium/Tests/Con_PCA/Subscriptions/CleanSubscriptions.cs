using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.DriverConfiguration;
using ConPCA_Selenium.Enums.Con_PCA;
using CSET_Selenium.Helpers.Con_PCA;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.SideMenu;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Subscriptions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ConPCA_Selenium.Tests.Con_PCA.CleanSubscriptions
{
    [TestFixture]
    public class SubscriptionCleaning : BaseTest
    {
        private IWebDriver driver;

        [Test]
        public void SubscriptionCleaningTest()
        {
            BaseConfiguration cf = new BaseConfiguration(Env.Dev.GetValue());
            driver = driver = BuildDriver(cf);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToConPCA("jessica.qu", "Abc123$$");

            SideMenu sideMenu = new SideMenu(driver);

            sideMenu.SelectSubscriptions();
            Subscriptions subscription = new Subscriptions(driver);
            List<String> subList = subscription.GetColumnCellsListByLabelName("Subscription Name");
            TableUtils table = new TableUtils(driver);
            foreach (String col in subList)
            {
                if (col.Contains("sandbox2"))
                {
                    subscription.DeleteSubscription(col);

                }
            }
        }
    }
}
