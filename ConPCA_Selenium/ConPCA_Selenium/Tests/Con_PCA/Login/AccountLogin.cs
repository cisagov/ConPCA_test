using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.DriverConfiguration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ConPCA_Selenium.Tests.Con_PCA
{
    [TestFixture]
    public class AccountLogin : BaseTest
    {
        private IWebDriver driver;

        [Test]
        public void Login()
        {
            BaseConfiguration cf = new BaseConfiguration("https://pca.dev.inltesting.xyz/login");
            driver = driver = BuildDriver(cf);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToConPCA("jessica.qu", "Abc123$$");
        }
    }
}
