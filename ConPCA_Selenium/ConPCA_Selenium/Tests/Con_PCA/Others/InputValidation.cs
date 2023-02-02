using ConPCA_Selenium.Enums.Con_PCA;
using CSET_Selenium.DriverConfiguration;
using CSET_Selenium.Helpers;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Customers;
using NUnit.Framework;
using OpenQA.Selenium;
using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.SideMenu;
using System;
using CSET_Selenium.ConPCA_Repository.Con_PCA;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Subscriptions;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Templates;

namespace ConPCA_Selenium.Tests.Con_PCA.Others
{
    [TestFixture]
    public class InputTesting : BaseTest
    {
        private IWebDriver driver;
        private SoftAssertions softAssertions = new SoftAssertions();

        [Test]
        public void InputVelidation()
        {
            BaseConfiguration cf = new BaseConfiguration(Env.Dev.GetValue());
            driver = BuildDriver(cf);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToConPCA(LoginInfo.User_Name.GetValue(), LoginInfo.Password.GetValue());

            SideMenu sideMenu = new SideMenu(driver);
            sideMenu.SelectCustomers();

            /*get a customer's from customer over view */
            Customers customer = new Customers(driver);
            int tableRowCount = customer.GetCustomerTableRows().Count;
            int randomRowNumber = NumberUtils.GenerateRandomNumberInt(1, tableRowCount);
            string customerName = customer.GetCustomerNameByRowNumber(randomRowNumber);
            string customerID = customer.GetCustomerIdentifierByRowNumber(randomRowNumber);
            string customerShortName = customer.GetCustomerShortNameByRowNumber(randomRowNumber);
            string customerAddress1 = customer.GetCustomerAddress1ByRowNumber(randomRowNumber);
            string customerCity = customer.GetCustomerCityByRowNumber(randomRowNumber);
            string customerState = customer.GetCustomerStateByRowNumber(randomRowNumber);
            string customerZip = customer.GetCustomerZipByRowNumber(randomRowNumber);
            /*click the customer  and get the info from Edit Customer page */
            customer.ClickCustomersTableEditByIdentifier(customerID);
            string selectedState = customer.GetSelectedState();
            softAssertions.Add("Selected state is incorrect on Edit page ", true, selectedState.Contains(customerState + " - "));
            /*test zip code*/
            string zipOne = "123456";
            string zipTwo = "abcde";
            //customer.SetCustomerZIP(zipOne);
            //customer.ClickSaveCustomerButton();//should stay the same page
            //softAssertions.Add("Zip code should be 5 digits ", true, customer.CheckIfElementExists(customer.GetUnsaveChangesPopup(), 1000));

            customer.SetCustomerZIP(zipTwo);
            customer.ClickSaveCustomerButton();//should stay the same page
            softAssertions.Add("Zip code should be numbers", false, customer.CheckIfElementExists(customer.GetUnsaveChangesPopup(), 1000));
            /*
             * Test Subscription
             */
            sideMenu.SelectSubscriptions();
            Subscriptions subscription = new Subscriptions(driver);
            string subscriptionName = subscription.GetSubscriptionNameByRowNumber(1);


            subscription.ClickSubscriptionTableRowByName(subscriptionName);
            subscription.SelectPrimaryContactByIndex(0);
            subscription.SelectAdminEmailByIndex(0);

            softAssertions.Add("Primary Contact can not be blank", true, subscription.CheckIfWarningExists("A primary contact must be selected", 1000));
            softAssertions.Add("Admin Email can not be blank", true, subscription.CheckIfWarningExists("Admin email contact must be selected", 1000));

            /*
             * Test Templates
             */
            sideMenu.SelectTemplates();
            Templates template = new Templates(driver);
            string templateName = template.GetTemplateNameByRowNumber(1);
            template.ClickEditButtonByTemplateName(templateName);
            template.ClickTemplateAttributesTab();
            template.GetTemplateAttTabFromAddress().Clear();

            template.ClickSaveTemplateButton();
            softAssertions.Add("From Address can not be blank", false, template.IfElementExists(template.GetTemplateSavedPopup(), 1000));

            softAssertions.AssertAll();
        }
    }
}
