using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {

        //Creating a constructor
        private readonly RemoteWebDriver _driver;
        public ManageListings()
        {
            _driver = GlobalDefinitions.driver;
        }

        //Click on Manage Listings Link
        private IWebElement manageListingsLink => _driver.FindElementByLinkText("Manage Listings");
        


        //Delete the listing
        private IWebElement delete => _driver.FindElementByXPath("(//i[@class='remove icon'])[1]");
       
        //Edit the listing
        private IWebElement edit => _driver.FindElementByXPath("(//i[@class='outline write icon'])[1]");
        
        //Click on Yes - for delete
        private IWebElement clickYesButton => _driver.FindElementByXPath("//button[contains(.,'Yes')]");
        
        //Click on No - for not deleting 
        private IWebElement clickNoButton => _driver.FindElementByXPath("//button[contains(.,'No')]");
       
        //Click on ShareSkill Button [ under shareskill button]
        private IWebElement ShareSkillButton => _driver.FindElementByXPath("//a[@class='ui basic green button']");
        

        //Enter the Title in textbox [ under shareskill button]
        private IWebElement Title => _driver.FindElementByXPath("//input[@name='title']");
       

        //Click on Save button [ under shareskill button]
        private IWebElement Save => _driver.FindElementByXPath("//input[@value='Save']");
       

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }

        
        internal void ClickOnmanageListingsLink()
        {
            //defining driver wait
            GlobalDefinitions.wait(5000);

            //Click on manageListingsLink
            manageListingsLink.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Manage Listings Link");

        }

        

        internal void Clickdelete()
        {
            delete.Click();

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                // perform action i.e Click on Yes 
                clickYesButton.Click();

                //Write Log reports
                Base.test.Log(LogStatus.Info, "Clicked on YES button for delete");
            }
            else
            {
                // perform action i.e Click on No
                clickNoButton.Click();

                //Write Log reports
                Base.test.Log(LogStatus.Info, "Clicked on NO  button for delete");
            }



        }

        internal void Clickedit()
        {
            //Edit the listing
            edit.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Edit Button");

        }


    }
}
