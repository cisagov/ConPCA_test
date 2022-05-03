﻿using CSET_Selenium.DriverConfiguration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSET_Selenium.Page_Objects.AssessmentInfo
{
    class AssessmentInfo : BasePage
    {
        private readonly IWebDriver driver;

        public AssessmentInfo(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //Element Locators

        private IWebElement DropdownSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'sector')]"));
            }
        }

        private IWebElement DropdownIndustry
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'industry')]"));
            }
        }

        private IWebElement DropdownAssetValue
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'assetValue')]"));
            }
        }

        private IWebElement DropdownExpectedEffort
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'size')]"));
            }
        }

        private IWebElement TextboxOrganizationName
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[contains(@name, 'edmOrganizationName')]"));
            }
        }

        private IWebElement TextboxAgency
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[contains(@name,'edmAgency')]"));
            }
        }

        private IWebElement DropdownOrganizationType
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'edmOrganizationType')]"));
            }
        }

        private IWebElement DropdownFacilitator
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name, 'edmFacilitator')]"));
            }
        }

        private IWebElement TextboxCriticalService
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//textarea[contains(@name,'criticalService')]"));
            }
        }

        private IWebElement DropdownPointOfContact
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//select[contains(@name,'critSvcPointOfContact')]"));
            }
        }

        private IWebElement CheckboxScoped
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//input[contains(@name,'edmIsScoped')]"));
            }
        }

        //Sector Dropdown options
        private IWebElement OptionChemicalSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Chemical Sector')]"));
            }
        }

        private IWebElement OptionCommercialFacilitiesSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Commercial')]"));
            }
        }

        private IWebElement OptionCommunicationsSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Communications')]"));
            }
        }

        private IWebElement OptionCriticalManufacturingSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Critical')]"));
            }
        }

        private IWebElement OptionDamsSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Dams Sector')]"));
            }
        }

        private IWebElement OptionDefenseIndustrialBaseSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Defense Industrial')]"));
            }
        }

        private IWebElement OptionEmergencyServicesSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Emergency Services')]"));
            }
        }

        private IWebElement OptionEnergySector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Energy')]"));
            }
        }

        private IWebElement OptionFinancialServicesSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Financial')]"));
            }
        }

        private IWebElement OptionFoodAndAgricultureSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Food and')]"));
            }
        }

        private IWebElement OptionGovernmentFacilitiesSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Government Facilities')]"));
            }
        }

        private IWebElement OptionHealthcareandPublicHealthSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Healthcare')]"));
            }
        }

        private IWebElement OptionInformationTechnologySector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Information Technology Sector')]"));
            }
        }

        private IWebElement OptionNuclearReactorsSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Nuclear Reactors')]"));
            }
        }

        private IWebElement OptionTransportationSystemsSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Transportation')]"));
            }
        }

        private IWebElement OptionWaterandWastewaterSystemsSector
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Water and')]"));
            }
        }

        //Industry Dropdown Options
        private IWebElement OptionPublicWaterSystems
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Public Water')]"));
            }
        }

        private IWebElement OptionPubliclyOwnedTreatmentWorks
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Publicly')]"));
            }
        }

        private IWebElement OptionOther
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//option[contains(text(),'Other')]"));
            }
        }

        //Standard Questions
        private IWebElement ExpandAll
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Expand')]"));
            }
        }

        private IWebElement StandardAnswerAccountManagementAllNo
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//label[contains(@class,'btn btn-no form-check-label ng-star-inserted active')]"));
            }
        }

        private IWebElement StandardAnswerAudit1Yes
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//label[contains(@class,'btn btn-no form-check-label ng-star-inserted answer')]/parent::div"));
            }
        }

        private IWebElement ObservationsTearOutSheets
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Observations')]"));
            }
        }

        private IWebElement ExecutiveSummary
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Executive')]"));
            }
        }

        private IWebElement SiteSummaryReport
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Site Summary')]"));
            }
        }

        private IWebElement SiteCybersecurityPlan
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Site Cyber')]"));
            }
        }

        private IWebElement SiteDetail
        {
            get
            {
                return WaitUntilElementIsVisible(By.XPath("//button[contains(text(),'Site Detail')]"));
            }
        }

        //Interaction Methods
        private void SetAssessmentName(String assessmentName)
        {
//            ClickWhenClickable(editBox_AssessmentName);
  //          editBox_AssessmentName.SendKeys(assessmentName);
        }

        private void SetAssessmentDate(DateTime assessmentDate)
        {
            //ClickWhenClickable(editBox_AssessmentDate);
            //editBox_AssessmentDate.SendKeys(assessmentDate.ToString());

        }


        //Aggregate Methods
        public void SetAssessmentInformation()
        {

            ClickNext();
        }

        public void SetAssessInfo()
        {
            DropdownSector.Click();
            OptionChemicalSector.Click();
            OptionCommercialFacilitiesSector.Click();
            OptionCommunicationsSector.Click();
            OptionCriticalManufacturingSector.Click();
            OptionDamsSector.Click();
            OptionDefenseIndustrialBaseSector.Click();
            OptionEmergencyServicesSector.Click();
            OptionEnergySector.Click();
            OptionFinancialServicesSector.Click();
            OptionFoodAndAgricultureSector.Click();
            OptionGovernmentFacilitiesSector.Click();
            OptionHealthcareandPublicHealthSector.Click();
            OptionInformationTechnologySector.Click();
            OptionNuclearReactorsSector.Click();
            OptionTransportationSystemsSector.Click();
            OptionWaterandWastewaterSystemsSector.Click();

            DropdownIndustry.Click();
            OptionPublicWaterSystems.Click();
            OptionPubliclyOwnedTreatmentWorks.Click();
            OptionOther.Click();

            ClickNext();
        }

        public void SetStandardQuestions()
        {
            //ExpandAll.Click();
            //ClickWhenClickable(StandardAnswerAccountManagementAllNo);
            ClickNext();
        }

        public void SetReports()
        {
            ObservationsTearOutSheets.Click();
            ExecutiveSummary.Click();
            SiteSummaryReport.Click();
            SiteCybersecurityPlan.Click();
            SiteDetail.Click();
            ClickNext();
        }

    }
}
