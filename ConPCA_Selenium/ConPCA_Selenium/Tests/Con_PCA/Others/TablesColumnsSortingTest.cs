﻿using CSET_Selenium.ConPCA_Repository.Login_Page;
using CSET_Selenium.DriverConfiguration;
using ConPCA_Selenium.Enums.Con_PCA;
using CSET_Selenium.Helpers.Con_PCA;
using CSET_Selenium.Page_Objects.Con_PCA_Page_Obj.SideMenu;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ConPCA_Selenium.Tests.Con_PCA.Others
{
    [TestFixture]
    public class AllTablesSortingTest : BaseTest
    {
        private IWebDriver driver;
        private SoftAssertions softAssertions = new SoftAssertions();

        [Test]
        public void SortingTest()
        {
            BaseConfiguration cf = new BaseConfiguration(Env.Dev.GetValue());
            driver = driver = BuildDriver(cf);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginToConPCA(LoginInfo.User_Name.GetValue(), LoginInfo.Password.GetValue());
            SideMenu sideMenu = new SideMenu(driver);

            /*test subscriptions table*/
            sideMenu.SelectSubscriptions();
            TableUtils table = new TableUtils(driver);
            List<String> cl = table.GetColumnCellsListByLabelName("Appendix A Date");
            cl.Sort();//ascending order
            cl.Reverse();//descending order
            List<String> listAfterSortShouldBe = cl;
            table.SortColumn("Appendix A Date", Sort.descending);
            List<String> listFromUI = table.GetColumnCellsListByLabelName("Appendix A Date");

            softAssertions.Add("Subscriptions table sorting failed, please see console output for details.", false, CompareLists(listAfterSortShouldBe, listFromUI));

            /*test templates table*/
            sideMenu.SelectTemplates();
            cl = table.GetColumnCellsListByLabelName("Template Name");
            cl.Sort();
            listAfterSortShouldBe = cl;
            //table.SortColumn("Template Name", Sort.ascending);
            table.SortColumn("Template Name", Sort.ascending);
            listFromUI = table.GetColumnCellsListByLabelName("Template Name");

            bool tmp = CompareLists(listAfterSortShouldBe, listFromUI);
            softAssertions.Add("Templates table sorting failed, please see console output for details.", false, CompareLists(listAfterSortShouldBe, listFromUI));

            /*test Customers table*/
            sideMenu.SelectCustomers();
            cl = table.GetColumnCellsListByLabelName("Name");
            cl.Sort();
            listAfterSortShouldBe = cl;
            table.SortColumn("Name", Sort.ascending);
            listFromUI = table.GetColumnCellsListByLabelName("Name");

            softAssertions.Add("Customers table sorting failed, please see console output for details.", false, CompareLists(listAfterSortShouldBe, listFromUI));

            /*test Sending Profiles table*/
            sideMenu.SelectSendingProfiles();
            cl = table.GetColumnCellsListByLabelName("Name");
            cl.Sort();
            listAfterSortShouldBe = cl;
            table.SortColumn("Name", Sort.ascending);
            listFromUI = table.GetColumnCellsListByLabelName("Name");

            softAssertions.Add("Profiles table sorting failed, please see console output for details.", false, CompareLists(listAfterSortShouldBe, listFromUI));

            /*test Recommendations table*/
            sideMenu.SelectRecommendation();
            cl = table.GetColumnCellsListByLabelName("Type");
            cl.Sort();
            listAfterSortShouldBe = cl;
            table.SortColumn("Type", Sort.ascending);
            listFromUI = table.GetColumnCellsListByLabelName("Type");

            softAssertions.Add("Recommendations table sorting failed, please see console output for details.", false, CompareLists(listAfterSortShouldBe, listFromUI));

            softAssertions.AssertAll();
        }

        private bool CompareLists(List<String> listShouldBe, List<String> listFromUI)
        {
            Boolean foundDifference = false;

            for (int i = 0; i < listShouldBe.Count - 1; i++)
            {
                if (!listShouldBe[i].Equals(listFromUI[i]))
                {
                    foundDifference = true;
                    Console.WriteLine("Row " + i + " should be " + listShouldBe[i] + ", while it is " + listFromUI[i]);
                }
            }

            return foundDifference;
        }
    }
}
