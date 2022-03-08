﻿using CSET_Selenium.DriverConfiguration;
using CSET_Selenium.Page_Objects.Assessment_Configuration;
using CSET_Selenium.Page_Objects.AssessmentInfo;
using CSET_Selenium.Page_Objects.Cybersecurity_Standards_Selection;
using CSET_Selenium.Page_Objects.Security_Assurance_Level;
using CSET_Selenium.Repository.Landing_Page;
using CSET_Selenium.Repository.Login_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CSET_Selenium.Tests.Create_Assessment
{
    class StandardAssessment
    {
        [TestFixture]
        public class CreateStandardAssessments : BaseTest
        {
            private IWebDriver driver;

            [Test]
            public void NERC2Rev6()
            {
                BaseConfiguration cf = new BaseConfiguration("http://cset-tst.inl.gov");
                driver = BuildDriver(cf);
                Assert.True(driver.Title.Contains("CSET"));

                LoginPage loginPage = new LoginPage(driver);
                loginPage.LoginToCSET("william.martin@inl.gov", "Password123");

                LandingPage createNewAssessment = new LandingPage(driver);
                createNewAssessment.CreateNewAssessment();

                AssessmentConfiguration assessmentConfiguration = new AssessmentConfiguration(driver);
                assessmentConfiguration.CreateStandardAssessment("Standard Assessment NERC2 Rev6", "Wayne Tech", "Gotham City", "New Jersey");

                AssessmentInfo assessmentInfo = new AssessmentInfo(driver);
                assessmentInfo.SetAssessmentInformation();

                //SAL Page
                SecurityAssuranceLevel securityAssuranceLevel = new SecurityAssuranceLevel(driver);
                
                //securityAssuranceLevel.SelectHeaderNist();
                securityAssuranceLevel.SelectHeaderGeneralRiskBased(); 
                securityAssuranceLevel.SelectHeaderSimple();
   

                //Cybersecurity Standards Selection Page
                CybersecurityStandardsSelection cybersecurityStandardsSelection = new CybersecurityStandardsSelection(driver);
                cybersecurityStandardsSelection.SetNerc_CIP_Rev6();
                cybersecurityStandardsSelection.SetCfats();
                cybersecurityStandardsSelection.SetIngaa();
                cybersecurityStandardsSelection.SelectOkAfterIngaa();
                cybersecurityStandardsSelection.SetCISV6();
                cybersecurityStandardsSelection.SetCISV8();
                cybersecurityStandardsSelection.SetCybersecMatModelCert102();
                cybersecurityStandardsSelection.SetCheckboxDODI8510();
                cybersecurityStandardsSelection.SetCheckboxCnssi1253BaselineV2Mar2014();
                cybersecurityStandardsSelection.SetCheckboxNercCipV3();
                cybersecurityStandardsSelection.SetCheckboxNercCipV4();
                cybersecurityStandardsSelection.SetCheckboxNercCipV5();
                cybersecurityStandardsSelection.SetCheckboxNercCipV6();
                cybersecurityStandardsSelection.SetCheckboxNistirV1();
                cybersecurityStandardsSelection.SetCheckboxNistirV1R1();
                cybersecurityStandardsSelection.SetCheckboxPci();
                cybersecurityStandardsSelection.SetCheckboxCjis();
                cybersecurityStandardsSelection.SetCheckboxC2M2();
                cybersecurityStandardsSelection.SetCheckboxCatalogRecsR7();
                cybersecurityStandardsSelection.SetCheckboxNistR2();
                cybersecurityStandardsSelection.SetCheckboxControlCorrelationIdV2();
                cybersecurityStandardsSelection.SetCheckboxAwwa();
                cybersecurityStandardsSelection.SelectContinueAfterAwwa();
                cybersecurityStandardsSelection.SetCheckboxHipaasr();
                cybersecurityStandardsSelection.SetCheckboxNistSpR5();
                cybersecurityStandardsSelection.SetCheckboxNistSpR4();
                cybersecurityStandardsSelection.SetCheckboxNistSpR4AppendixJ();
                cybersecurityStandardsSelection.SetCheckboxNistSpR3();
                cybersecurityStandardsSelection.SetCheckboxContinuousReqEveryYear();
                cybersecurityStandardsSelection.SetCheckboxContinuousY1();
                cybersecurityStandardsSelection.SetCheckboxContinuousY2();
                cybersecurityStandardsSelection.SetCheckboxContinuousY3();
                cybersecurityStandardsSelection.SetCheckboxFrameworkImprovingCriticalInfraCyber();
                cybersecurityStandardsSelection.SetCheckboxNeiCyberPlanNuclearPowerReactors();
                cybersecurityStandardsSelection.SelectOkAfterIngaa();
                cybersecurityStandardsSelection.SetCheckboxNrcRegGuide571();
                cybersecurityStandardsSelection.SetCheckboxHLCIA();
                cybersecurityStandardsSelection.SetCheckboxHighANSSec();
                cybersecurityStandardsSelection.SetCheckboxNistSpR3AppendixI();
                cybersecurityStandardsSelection.SetCheckboxNistSp80082();
                cybersecurityStandardsSelection.SetCheckboxNistSp80082R1();
                cybersecurityStandardsSelection.SetCheckboxNistSp80082R2();
                cybersecurityStandardsSelection.SetCheckboxVadr();
                cybersecurityStandardsSelection.SetCheckboxKeyQuestions();
                cybersecurityStandardsSelection.SetCheckboxUniversalQuestions();
                cybersecurityStandardsSelection.SetCheckboxNistSpSupplyChainRiskManagement();
                cybersecurityStandardsSelection.SetCheckboxFaa();
                cybersecurityStandardsSelection.SetCheckboxDefiningSecZoneArchRailTransitProtectCritZones();
                cybersecurityStandardsSelection.SetCheckboxFaaPortableElectronicDevices();
                cybersecurityStandardsSelection.SetCheckboxTsaPipelineSecGuidelinesApril2011();
                cybersecurityStandardsSelection.SetCheckboxTsaPipelineSecGuidelinesMarch208wApril2021Revision();

                //Standards Questions Page
                assessmentInfo.SetAssessmentInformation();

                //Analysis Dashboard Page
                assessmentInfo.SetAssessmentInformation();

                //Control Priorities Page
                assessmentInfo.SetAssessmentInformation();

                //Standards Summary Page
                assessmentInfo.SetAssessmentInformation();

                //Ranked Categories Page
                assessmentInfo.SetAssessmentInformation();

                //Results By Category Page
                assessmentInfo.SetAssessmentInformation();
            }
        }
    }
}
