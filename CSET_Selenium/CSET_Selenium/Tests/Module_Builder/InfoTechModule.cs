﻿using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.DriverConfiguration;
using CSET_Selenium.Repository.Landing_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSET_Selenium.Tests.Module_Builder
{
    class InformationTechnologyModule
    {
        [TestFixture]
        public class Module_Builder : BaseTest
        {
            private IWebDriver driver;

            [Test]
            public void InformationTechnologyModule()
            {
                //Create a base configuration
                BaseConfiguration cf = new BaseConfiguration("http://cset-tst.inl.gov");
                driver = BuildDriver(cf);
                Assert.True(driver.Title.Contains("CSET"));

                //Login and navigate to module builder
                LoginPage loginPage = new LoginPage(driver);
                loginPage.LoginToCSET("william.martin@inl.gov", "Password123");

                LandingPage createNewAssessment = new LandingPage(driver);
                createNewAssessment.NavigateToModuleBuilder();

                //Create a new module
                ModuleBuilder newModule = new ModuleBuilder(driver);
                newModule.CreateNewModule();

                //Set module details using the Information Technology category
                newModule.SetModuleDetails("Information Technology Test", "Test2", "'Information Technology' category module test", "Information Technology");
                Thread.Sleep(4000);
            }
        }
    }
}