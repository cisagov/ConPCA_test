using CSET_Selenium.ConPCA_Repository.Con_PCA;
using ConPCA_Selenium.Enums.Con_PCA;
using CSET_Selenium.Helpers.Con_PCA;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.Subscriptions
{
    class Subscriptions : ConPCABase
    {
        private readonly IWebDriver driver;
        TableUtils table;

        public Subscriptions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            table = new TableUtils(driver);
        }

        //Element Locators

        private IWebElement ButtonNewSubscription
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//span[text()=' New Subscription ']"));
            }
        }

        private IWebElement ButtonAssignCustomer
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//span[text()=' Assign Customer ']"));
            }
        }

        private IWebElement ButtonCreateSubscription
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[@type='submit']"));
            }
        }

        private IWebElement TableCustomer
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-table[@class='mat-table cdk-table mat-sort']"));
            }
        }

        private IWebElement SelectPrimaryContact
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-select[@formcontrolname='primaryContact']"));
            }
        }

        private IWebElement SelectAdminEmail
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-select[@formcontrolname='adminEmail']"));
            }
        }

        private IWebElement SelectSendingProfile
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-select[@formcontrolname='sendingProfile']"));
            }
        }

        private IWebElement TextboxTargetEmailDomain
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@formcontrolname='targetDomain']"));
            }
        }

        private IWebElement TextboxTargetRecipients
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//textarea[@formcontrolname='csvText']"));
            }
        }

        private IWebElement TextNewSubcriptionName
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-dialog-content[@formcontrolname='csvText']"));
            }
        }

        private IWebElement TableSubcriptions
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//mat-table[@class='mat-table cdk-table mat-sort']"));
            }
        }

        private IWebElement ButtonActions
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//span[text() =' Actions']"));
            }
        }

        private IWebElement ButtonLaunch
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[text() ='Launch ']"));
            }
        }

        private IWebElement ButtonStop
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[text() ='Stop ']"));
            }
        }

        private IWebElement ButtonOpenCalendar
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[@aria-label ='Open calendar']"));
            }
        }

        private IWebElement LinkActionsDelete
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//delete-subscription/button"));
            }
        }

        private IWebElement LinkPopupDeleteLink
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//span[text() =' Delete ']"));
            }
        }

        private IWebElement TextboxDeletePopupSubscriptionName
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@id = 'confirmDeleteInput']"));
            }
        }

        private IWebElement TextboxStartDate
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@formcontrolname='startDate']"));
            }
        }

        private IWebElement TextboxStartTime
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[@formcontrolname='startTime']"));
            }
        }

        private IWebElement TabCycles
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//div[@role = 'tab']/div[text() = 'Cycles']"));
            }
        }

        private IWebElement TabSubscriptionConfiguration
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//div[@role = 'tab']/div[text() = 'Subscription Configuration']"));
            }
        }

        private IWebElement ButtonSaveSubscription
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//div[text() = 'Save Subscription']"));
            }
        }

        //Interaction Methods

        private void ClickNewSubscriptionButton()
        {
            ButtonNewSubscription.Click();
        }

        private void ClickSaveSubscriptionButton()
        {
            ButtonSaveSubscription.Click();
        }

        public void ClickCyclesTab()
        {
            TabCycles.Click();
            WaitUntilElementIsVisible(Find(By.XPath(".//mat-card-title[text() = 'Cycles']")), 2);
        }

        public void ClickSubscriptionConfigurationTab()
        {
            TabSubscriptionConfiguration.Click();
            WaitUntilElementIsVisible(Find(By.XPath(".//h2[text() = 'Customer/Organization']")), 2);
        }

        private void ClickActionsButton()
        {
            ButtonActions.Click();
        }

        private void ClickOpenCalendar()
        {
            ButtonOpenCalendar.Click();
        }

        private void ClickLaunchButton()
        {
            ButtonLaunch.Click();
        }

        private void ClickStopButton()
        {
            ButtonStop.Click();
        }

        private void ClickActionsDeleteLink()
        {
            LinkActionsDelete.Click();
        }

        private void ClickDeletePopupDeleteLink()
        {
            LinkPopupDeleteLink.Click();
        }

        private void ClickAssignCustomerButton()
        {
            ButtonAssignCustomer.Click();
        }

        private void ClickCreateSubscriptionButton()
        {
            ButtonCreateSubscription.Click();
        }

        private void ClickEmailDomain()
        {
            ClickWhenClickable(TextboxTargetEmailDomain);
        }

        private void ClickTargetRecipients()
        {
            ClickWhenClickable(TextboxTargetRecipients);
        }

        private void SetDeletePopupSubscriptionName(String name)
        {
            TextboxDeletePopupSubscriptionName.SendKeys(name);
        }



        //Aggregate Methods
        public void CreateNewSubscription()
        {
            ClickNewSubscriptionButton();
        }

        public void AssignCustomer()
        {
            ClickAssignCustomerButton();
        }

        public IWebElement GetCustomerTable()
        {
            return TableCustomer;
        }

        public void SetStartDate(String date)
        {
            TextboxStartDate.Clear();
            TextboxStartDate.SendKeys(date);
        }

        public void SetStartTime(String time)
        {
            TextboxStartTime.Clear();
            TextboxStartTime.SendKeys(time);
        }

        public IWebElement GetSubscriptionsTable()
        {
            return TableSubcriptions;
        }

        //public ReadOnlyCollection<IWebElement> GetSubscriptionsTableRows()
        public IList<IWebElement> GetSubscriptionsTableRows()
        {
            return GetSubscriptionsTable().FindElements(By.XPath(".//mat-row"));
        }

        public void ClickCustomerTableRowByName(String name)
        {
            //if (name.Contains("'"))
            //{
            //    name = name.Replace("'", "\'");
            //}
            //GetCustomerTable().FindElement(By.XPath("mat-row/mat-cell[text() = ' " + name + " ']")).Click();
            GetCustomerTable().FindElement(By.XPath("mat-row/mat-cell[contains(text(), \"" + name + "\")]")).Click();
        }

        public void SelectPrimaryContactByName(String contactName)
        {
            ClickWhenClickable(SelectPrimaryContact);
            driver.FindElement(By.XPath("//span[text()=' " + contactName + " ']")).Click();
        }

        public void SelectPrimaryContactByIndex(int index)
        {
            ClickWhenClickable(SelectPrimaryContact);
            driver.FindElement(By.XPath("//div/mat-option[" + (index + 1) + "]")).Click();
        }

        public void SelectAdminEmailByIndex(int index)
        {
            ClickWhenClickable(SelectAdminEmail);
            driver.FindElement(By.XPath("//div/mat-option[" + (index + 1) + "]")).Click();
        }

        public void SelectSendingProfileByIndex(int index)
        {
            ClickWhenClickable(SelectSendingProfile);
            driver.FindElement(By.XPath("//div/mat-option[" + (index + 1) + "]")).Click();
        }

        public void SetTargetEmailDomain(String emailDomain)
        {
            ClickEmailDomain();
            TextboxTargetEmailDomain.SendKeys(Keys.Control + "a");
            TextboxTargetEmailDomain.SendKeys(Keys.Delete);
            TextboxTargetEmailDomain.SendKeys(emailDomain);
        }

        public void SetTargetRecipients(String recipients)
        {
            ClickTargetRecipients();
            TextboxTargetRecipients.SendKeys(Keys.Control + "a");
            TextboxTargetRecipients.SendKeys(Keys.Delete);
            TextboxTargetRecipients.SendKeys(recipients);
        }

        public String Submit()
        {
            ClickCreateSubscriptionButton();
            //get newly created subscription name
            String xpath = ".//mat-dialog-content/div[contains(text(), 'Your subscription was created as')]";

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IWebElement title = wait.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(By.XPath(xpath));
            //});
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until
            (ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            IWebElement popUpMsg = driver.FindElement(By.XPath(xpath));
            String subscriptionName = popUpMsg.Text.Split(' ')[5];
            popUpMsg.FindElement(By.XPath("../../following-sibling::div/mat-dialog-actions/button/span[text() = ' OK ']")).Click();

            return subscriptionName;
        }

        public String getTitleClassByColumnName(String name)
        {
            String tmp = GetSubscriptionsTable().FindElement(By.XPath(".//mat-header-cell[//div/div[text() = '" + name + "']]")).GetAttribute("class");
            return tmp;
        }

        public List<String> GetColumnCellsListByLabelName(String name)
        {
            String classAttributeString = GetSubscriptionsTable().FindElement(By.XPath(".//div[text() = '" + name + "']/ancestor::mat-header-cell")).GetAttribute("class");
            String commonClassText = classAttributeString.Substring(classAttributeString.IndexOf("cdk-column-")); ;
            IList<IWebElement> rows = GetSubscriptionsTableRows();
            List<String> columnCellsList = new List<String>();
            for (var i = 0; i < rows.Count; i++)
            {
                columnCellsList.Add(rows[i].FindElement(By.XPath(".//mat-cell[contains(@class, '" + commonClassText + "')]")).Text.Trim());
            }
            return columnCellsList;
        }

        public void SortColumn(String columnName, Sort sort)
        {
            IWebElement columnTitle = GetSubscriptionsTable().FindElement(By.XPath(".//div[text() = '" + columnName + "']"));
            columnTitle.Click();
            String ariaSort = columnTitle.FindElement(By.XPath("../..")).GetAttribute("aria-sort");
            do
            {
                columnTitle.Click();
            } while (!(columnTitle.FindElement(By.XPath("../..")).GetAttribute("aria-sort").Equals(sort.ToString())));
            driver.FindElement(By.XPath("//span[@class = 'loggin-user']")).Click();
        }

        public void DeleteSubscription(String subscriptionName)
        {
            table.ClickCommonTableRowByName(subscriptionName);
            ClickActionsButton();
            ClickActionsDeleteLink();
            SetDeletePopupSubscriptionName(subscriptionName);
            ClickDeletePopupDeleteLink();
            Thread.Sleep(2);
            //WaitUntilElementIsVisible(table.GetCommonTable(), 2);
        }

        public void ClickSubscriptionTableRowByName(String subscriptionName)
        {
            IList<IWebElement> rows = GetSubscriptionsTableRows();
            for (var i = 0; i < rows.Count; i++)
            {
                if (rows[i].FindElement(By.XPath(".//mat-cell[1]")).Text.Equals(subscriptionName))
                {
                    rows[i].FindElement(By.XPath(".//mat-cell[1]")).Click();
                    break;
                }
            }
            WaitUntilElementIsVisible(Find(By.XPath(".//div[text() = 'Subscription Configuration']")), 2);
        }
        /*
         * provide column title and a cell text in the column, return the subscription name
         */
        public void ClickSubscriptionTableRowByColumnLable(string columnLabel, string cellText)
        {
            IList<IWebElement> tableRows = GetSubscriptionsTableRows();
            IWebElement table = GetSubscriptionsTable();
            string classAtrribute = GetSubscriptionsTable().FindElement(By.XPath(".//mat-header-row//mat-header-cell[div/div[text() = '" + columnLabel + "']]")).GetAttribute("class");
            string[] classAtrributeSplitted = classAtrribute.Split(' ');
            string commonAttributeWithMatCell = classAtrributeSplitted[4] + " " + classAtrributeSplitted[5];

            table.FindElement(By.XPath(".//mat-row//mat-cell[contains(text(), '" + cellText + "')]")).Click();
            WaitUntilElementIsVisible(By.XPath("//h1[contains(text(), 'Edit Subscription:')]"),3);
            
        }
        /*
         *get the name on Edit page 
         */
        public string GetSubscriptionName()
        {
            string tmp = driver.FindElement(By.XPath(".//div[@class = 'header-title']/h1")).Text;
            Console.WriteLine("Title is : "+tmp);
            string nameWithStatus = driver.FindElement(By.XPath(".//div[@class = 'header-title']/h1")).Text.Split(':')[1].Trim();
            if (nameWithStatus.Contains("("))
            {
                return nameWithStatus.Split('(')[0].Trim();
            }
            else
            {
                return nameWithStatus;
            }
            
        }

            public String GetSubscriptionNameByRowNumber(int rowNum)
        {
            IList<IWebElement> rows = GetSubscriptionsTableRows();
            return rows[rowNum - 1].Text.Split('\r')[0].Replace("\n", "");
        }

        public bool CheckIfWarningExists(string warningMsg, int millionSec)
        {
            return CheckIfElementExists(Find(By.XPath("//mat-error[contains(text(), '" + warningMsg+"')]")), millionSec);
            //return CheckIfElementExists(Find(By.XPath("//div/*[contains(text(), '" + warningMsg + "']")), millionSec);
        }

        public void LaunchSubscription()
        {
            ClickActionsButton();
            ClickLaunchButton();

            if (CheckIfElementExists("//mat-error[contains(text(), 'Start Date cannot be in the past')]", 1))
            {
                ClickOpenCalendar();
                Find(By.XPath("//div[contains(@class, 'mat-calendar-body-today')]")).Click();
                ClickSaveSubscriptionButton();
                ClickOKFromPopup();
                ClickActionsButton();
                ClickLaunchButton();             
            }
           
            ClickYesOrNoFromPopup(YesNo.Yes);
            ClickOKFromPopup();
        }

        public void StopSubscription()
        {
            ClickActionsButton();
            ClickStopButton();     
            ClickYesOrNoFromPopup(YesNo.Yes);
            ClickOKFromPopup();
        }

        public string GetCycleReportDownloadButtonAttribute(string attributeName)
        {
            return Find(By.XPath("//th[text() = 'Cycle']/following-sibling::td/button")).GetAttribute(attributeName);
            
        }
    }
}