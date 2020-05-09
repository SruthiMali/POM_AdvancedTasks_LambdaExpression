using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class ManageListings
    {
        /*
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }*/

        private readonly RemoteWebDriver _driver;

        //Creating a constructor
        public ManageListings(RemoteWebDriver driver) => _driver = driver;


        //Click on Manage Listings Link
        IWebElement manageListingsLink => _driver.FindElementByLinkText("Manage Listings");

     

        //View the listing
        IWebElement view => _driver.FindElementByXPath("//i[@class='eye icon'])[1]");


        //Delete the listing
        IWebElement delete => _driver.FindElementByXPath("//table[1]/tbody[1]");


        //Edit the listing
        IWebElement edit => _driver.FindElement(By.XPath("//i[@class='outline write icon'])[1]"));
}

       //Click on Yes - for delete
      

       IWebElement YesButton => _driver.FindElement(By.XPath("//button[contains(.,'Yes')]"));


    //Click on No - for not deleting 
    [FindsBy(How = How.XPath, Using = "//button[contains(.,'No')]")]
        private IWebElement clickNoButton { get; set; }
        

        //Click on ShareSkill Button [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillButton { get; set; }


        //Enter the Title in textbox [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement Title { get; set; }

        //Click on Save button [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//input[@value='Save'] ")]
        private IWebElement Save { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }

        public void ClickOnShareSkillButton()
        {
            // Because of application problem we need to click Skill button first, then ManageListings Link
            //Click on ShareSkill Button
           
            //defining driver wait
            GlobalDefinitions.wait(5000);

            //Click on Shareskill button
            ShareSkillButton.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Shareskill Button");

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

        internal void ClickView()
        {
            ////View the listing
            view.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Save Button");
        }

        internal void Clickedit()
        {
            //Edit the listing
            edit.Click();

            //Clear the title textbox
            Title.Clear();

            //Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Title"));
            Title.SendKeys("Selenium");

            //Click on Save button
            Save.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Edit Button");

        }

        internal void Clickdelete()
        {

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

    }
}
