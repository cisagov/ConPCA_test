using ConPCA_Selenium.Enums.Con_PCA;
using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.DriverConfiguration;
using NUnit.Framework;
using OpenQA.Selenium;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Subscriptions;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.SideMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSET_Selenium.Tests.Con_PCA.SubscriptionsCycleReport
{
    [TestFixture]
    public class MidCycleReport : BaseTest
    {
        private IWebDriver driver;

        [Test]
        public void MidCycleTest()
        {
            BaseConfiguration cf = new BaseConfiguration(Env.Dev.GetValue());
            driver = BuildDriver(cf);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToConPCA(LoginInfo.User_Name.GetValue(), LoginInfo.Password.GetValue());

            SideMenu sideMenu = new SideMenu(driver);
            sideMenu.SelectSubscriptions();

            /*selec a stopped or created subscription */
            Subscriptions subscription = new Subscriptions(driver);
            subscription.ClickSubscriptionTableRowByColumnLable("Status", "Stopped");
            string subName = subscription.GetSubscriptionName();

            /*
             *launch the subscription 
             */
            subscription.LaunchSubscription();
            sideMenu.SelectSubscriptions();
            IList<IWebElement> rows = subscription.GetSubscriptionsTableRows();
            bool subscriptionRunning = rows.Any(
                fb => (fb.Text.Contains(subName)) && (fb.Text.Contains("Running"))
            );

            Assert.IsTrue(subscriptionRunning, "The subscription was not successfully launched.");

            /*
             * Verify the cycle report
             * 
             */
            subscription.ClickSubscriptionTableRowByName(subName);
            subscription.ClickCyclesTab();
            Assert.IsTrue(subscription.GetCycleReportDownloadButtonAttribute("disabled").Equals("true"), "The Cycle report download button is not disabled.");

            /*
             * stop subscription
             */
            subscription.ClickSubscriptionConfigurationTab();
            subscription.StopSubscription();
            sideMenu.SelectSubscriptions();
            rows = subscription.GetSubscriptionsTableRows();
            subscriptionRunning = rows.Any(
                fb => (fb.Text.Contains(subName)) && (fb.Text.Contains("Stopped"))              
            );

            Assert.IsTrue(subscriptionRunning, "The subscription was not successfully stopped.");
            Console.WriteLine("hello");
        }
    }
}
