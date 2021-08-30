﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSET_Selenium.Repository.RegisterNewUserAccount
{
    class RegisterNewUserAccount
    {
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement textboxFirstName;

        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement textboxLastName;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement textboxEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='confirmEmail']")]
        private IWebElement textboxConfirmEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='securityQustion1']")]
        private IWebElement dropdownSecurityQustion1;

        [FindsBy(How = How.XPath, Using = "//input[@name='SecurityAnswer1']")]
        private IWebElement textboxSecurityAnswer1;

        [FindsBy(How = How.XPath, Using = "//input[@name='securityQustion2']")]
        private IWebElement dropdownSecurityQustion2;

        [FindsBy(How = How.XPath, Using = "//input[@name='SecurityAnswer2']")]
        private IWebElement textboxSecurityAnswer2;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Register')]")]
        private IWebElement buttonRegister;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Login')]")]
        private IWebElement textlinkLogin;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Forgot Password')]")]
        private IWebElement textlinkForgotPassword;
    }
}