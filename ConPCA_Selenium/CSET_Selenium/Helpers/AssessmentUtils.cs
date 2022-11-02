﻿using CSET_Selenium.DriverConfiguration;
using CSET_Selenium.Helpers;
using CSET_Selenium.Page_Objects.Assessment_Configuration;
using CSET_Selenium.Page_Objects.AssessmentInfo;
using CSET_Selenium.Page_Objects.Cybersecurity_Standards_Selection;
using CSET_Selenium.Page_Objects.Maturity_Models;
using CSET_Selenium.Page_Objects.Security_Assurance_Level;
using CSET_Selenium.Repository.Landing_Page;
using CSET_Selenium.Repository.Login_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace CSET_Selenium.Helpers
{
    class AssessmentUtils
    {
        private Random r = new Random();
        private readonly IWebDriver driver;
        private Dictionary<string, string> statMap = new Dictionary<string, string>();
        private int generalRiskNum;


        private void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();
        }

        public AssessmentUtils(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Open up a all standard questions
        private void OpenStandardQuestions()
        {
            var el = driver.FindElement(By.XPath("//button[contains(text(), 'Expand All')]"));
            el.Click();
        }

        public void ExpandAll()
        {
            OpenStandardQuestions();
        }


        //Find open questions and answer yes to all
        private void ClickYes()
        {
            List<IWebElement> yesList = new List<IWebElement>(driver.FindElements(By.XPath("//label[contains(text(),'Yes')]")));
            foreach (IWebElement el in yesList)
            {
                MoveToElement(el);
                el.Click();
            }
        }

        private void ClickNo()
        {
            List<IWebElement> noList = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='subcat-question-list']//label[@class='mat-tooltip-trigger btn form-check-label btn-no ng-star-inserted']")));
            for(int i =0; i < noList.Count(); i+=2)
            {
                MoveToElement(noList[i]);
                noList[i].Click();
            }
        }
        private void ClickNoMaturityModel()
        {
            List<IWebElement> noList = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='subcat-question-list']//label[@class='mat-tooltip-trigger btn form-check-label btn-no ng-star-inserted']")));
            foreach(IWebElement el in noList)
            {
                MoveToElement(el);
                el.Click();
            }
        }

        public void AnswerYesToAll()
        {
            ClickYes();
        }

        private void ClickNext()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Next')]")).Click();
        }

        private void Home()
        {
            driver.FindElement(By.XPath("//app-logo-cset")).Click();
        }

        //Walking through an ACET Maturity Model
        private void ACET()
        {
            Thread.Sleep(5000);
            var rand = r.Next(6);
            List<IWebElement> riskList = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='mb-4']//div[@class='irp-risk cursor-pointer']")));
            for(int i=rand; i < riskList.Count(); i += rand)
            {
                riskList[i].Click();
                rand = r.Next(6);
            }
            ClickNext();
            Home();
        }

        private void CMMC(Boolean changing)
        {
            ExpandAll();
            ClickNoMaturityModel();
            if (changing)
            {
                ClickYes();
            }
            ClickNext();
            Home();
        }

        private void CMMC2(Boolean changing)
        {
            ExpandAll();
            ClickNoMaturityModel();
            if (changing)
            {
                ClickYes();
            }
            ClickNext();
            Home();
        }

        private void CRR(Boolean changing)
        {
            ExpandAll();
            ClickNoMaturityModel();
            if (changing)
            {
                ClickYes();
            }
            ClickNext();
            Home();
        }

        private void EDM(Boolean changing)
        {
            ExpandAll();
            ClickNoMaturityModel();
            if (changing)
            {
                ClickYes();
            }
            ClickNext();
            Home();
        }

        private void CIS(Boolean changing)
        {

        }

        private void RRA(Boolean changing)
        {
            ExpandAll();
            ClickNoMaturityModel();
            if (changing)
            {
                ClickYes();
            }
            ClickNext();
            Home();
        }

        //Utility that creates a randomized standard CSET assessment
        public void NewRandomStandard()
        {
            //Create a base configuration
            Assert.True(driver.Title.Contains("CSET"));

            //Login and fill out the assessment information
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToCSET("kyle.hanson@inl.gov", "Nitocket14$");

            LandingPage createNewAssessment = new LandingPage(driver);
            createNewAssessment.CreateNewAssessment();
            AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
            assessmentConfiguration.CreateStandardAssessment("Standard Assessment (From Assessment Utils)", "Wayne Tech", "Gotham City", "New Jersey");
            statMap.Add("Standard Assessment (From Assessment Utils)", "Assessment Name");

            AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
            assessmentInfo.SetSALAssessmentInfo();
            assessmentInfo.GetAssessmentInfo().ToList().ForEach(x => statMap.Add(x.Key, x.Value));

            SecurityAssuranceLevel sal = new SecurityAssuranceLevel(driver);
            generalRiskNum = r.Next(9);
            sal.SelectHeaderGeneralRiskBased();
            sal.SetRandomGeneralRisk(generalRiskNum);
            sal.SelectHeaderNist();
            Thread.Sleep(3000);
            for (int i = 0; i < 5; i++)
            {
                sal.SetRandomNistCheck();
            }
            sal.GetStandardMap().ToList().ForEach(x => statMap.Add(x.Key, x.Value));
            sal.SetRandomNistQuestion();
            sal.ClickNext();

            CybersecurityStandardsSelection css = new CybersecurityStandardsSelection(driver);
            css.RecommendedStandards();
            Thread.Sleep(5000);
            ExpandAll();
            AnswerYesToAll();
            ClickNo();
            Thread.Sleep(10000);
            for(int i =0; i < statMap.Count(); i++)
            {

                Console.WriteLine(statMap.ElementAt(i));
            }
            css.ClickNext();
        }

        //Uses the random assessment above as a starting point, but answers 'Yes' to more questions
        public void ChangedStandardAssessment(Dictionary<string, string> valsToChange)
        {
            LandingPage createNewAssessment = new LandingPage(driver);
            createNewAssessment.CreateNewAssessment();
            AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
            assessmentConfiguration.CreateStandardAssessment(valsToChange.FirstOrDefault(x => x.Value == "Assessment Name").Key + " " + 2, "Wayne Tech", "Gotham City", "New Jersey");

            AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
            assessmentInfo.SetChangedAssessmentInfo(valsToChange);

            SecurityAssuranceLevel sal = new SecurityAssuranceLevel(driver);
            sal.SelectHeaderGeneralRiskBased();
            sal.SetRandomGeneralRisk(generalRiskNum);
            sal.SelectHeaderNist();
            Thread.Sleep(3000);
            sal.SetNistCheckChanged(valsToChange);
            sal.ClickNext();

            CybersecurityStandardsSelection css = new CybersecurityStandardsSelection(driver);
            css.RecommendedStandards();
            Thread.Sleep(5000);
            ExpandAll();
            AnswerYesToAll();
            Thread.Sleep(10000);
            //css.ClickNext();
        }

        //Utility that creates a randomized cyber CSET assessment
        public void NewRandomMaturityModel()
        {
            Assert.True(driver.Title.Contains("CSET"));

            //Login and fill out the assessment information
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToCSET("kyle.hanson@inl.gov", "Nitocket14$");

            LandingPage createNewAssessment = new LandingPage(driver);
            createNewAssessment.CreateNewAssessment();
            AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
            assessmentConfiguration.CreateMaturityModelAssessment("Cyber Assessment (From Assessment Utils)", "Wayne Tech", "Gotham City", "New Jersey");

            statMap.Add("Cyber Assessment (From Assessment Utils)", "Assessment Name");

            AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
            assessmentInfo.SetSALAssessmentInfo();
            assessmentInfo.GetAssessmentInfo().ToList().ForEach(x => statMap.Add(x.Key, x.Value));

            //Select a Maturity Model
            MaturityModelsPage mat = new MaturityModelsPage(driver);
            Random r = new Random();
            var rand = 1;   //r.Next(7);

            if (rand == 0)
            {
                statMap.Add("ACET", "Maturity Model");
                mat.SelectACET();
                ACET();
            }
            else if (rand == 1)
            {
                statMap.Add("CMMC1", "Maturity Model");
                mat.SelectCMMC1();
                CMMC(false);
            }
            else if (rand == 2)
            {
                statMap.Add("CMMC2", "Maturity Model");
                mat.SelectCMMC2();
                CMMC2(false);
            }
            else if (rand == 3)
            {
                statMap.Add("CRR", "Maturity Model");
                mat.SelectCRR();
                CRR(false);
            }
            else if (rand == 4)
            {
                statMap.Add("EDM", "Maturity Model");
                mat.SelectEDM();
                EDM(false);
            }
            else if (rand == 5)
            {
                statMap.Add("CIS", "Maturity Model");
                mat.SelectCIS();
                CIS(false);
            }
            else
            {
                statMap.Add("RRA", "Maturity Model");
                mat.SelectRRA();
                RRA(false);
            }

        }

        //Utility that creates a randomized cyber CSET assessment
        public void ChangedMaturityModel(Dictionary<string, string> valsToChange)
        {

            LandingPage createNewAssessment = new LandingPage(driver);
            createNewAssessment.CreateNewAssessment();
            AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
            assessmentConfiguration.CreateMaturityModelAssessment(valsToChange.FirstOrDefault(x => x.Value == "Assessment Name").Key + " " + 2, "Wayne Tech", "Gotham City", "New Jersey");

            AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
            assessmentInfo.SetChangedAssessmentInfo(valsToChange);


            //Select a Maturity Model
            MaturityModelsPage mat = new MaturityModelsPage(driver);
            if (valsToChange.ContainsKey("ACET"))
            {
                mat.SelectACET();
                ACET();
            }
            if (valsToChange.ContainsKey("CMMC1"))
            {
                mat.SelectCMMC1();
                CMMC(true);
            }
            if (valsToChange.ContainsKey("CMMC2"))
            {
                mat.SelectCMMC2();
                CMMC2(true);
            }
            if (valsToChange.ContainsKey("CRR"))
            {
                mat.SelectCRR();
                CRR(true);
            }
            if (valsToChange.ContainsKey("EDM"))
            {
                mat.SelectEDM();
                EDM(true);
            }
            if (valsToChange.ContainsKey("CIS"))
            {
                mat.SelectCIS();
                CIS(true);
            }
            if (valsToChange.ContainsKey("RRA"))
            {
                mat.SelectRRA();
                RRA(true);
            }

        }

        //Utility that creates a randomized Network Diagram CSET assessment
        public void NewNetDiagram()
        {
            //Create a base configuration
            Assert.True(driver.Title.Contains("CSET"));

            //Login and fill out the assessment information
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToCSET("kyle.hanson@inl.gov", "Nitocket14$");

            LandingPage createNewAssessment = new LandingPage(driver);
            createNewAssessment.CreateNewAssessment();
            AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
            assessmentConfiguration.CreateNetworkDiagramAssessment("Network Diagram (From Assessment Utils)", "Wayne Tech", "Gotham City", "New Jersey");
        }

        public Dictionary<string, string> GetStats()
        {
            return statMap;
        }
    }
}
