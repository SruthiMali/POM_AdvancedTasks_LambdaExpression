using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Excel.Log;
using RelevantCodes.ExtentReports;
using MarsFramework.Pages;
using AutoItX3Lib;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Remote;
//https://www.youtube.com/watch?v=jgKgbVcQ-1U&feature=youtu.be for lambda expressions
namespace Marsframework.Pages

{
    internal class ShareSkill
    {
        //Creating a constructor
        private readonly RemoteWebDriver _driver;
        public ShareSkill()
        {
            _driver = GlobalDefinitions.driver;
        }

        //Click on ShareSkill Button
        private IWebElement ShareSkillButton => _driver.FindElementByXPath("//a[@class='ui basic green button']");



        //Enter the Title in textbox
        private IWebElement Title => _driver.FindElementByXPath("//input[@name='title']");


        //Enter the Description in textbox
        private IWebElement Description => _driver.FindElementByXPath("//textarea[@name='description']");


        //Click on Category Dropdown // select the dropdown list
        private IWebElement CategoryDropDown => _driver.FindElementByXPath("//select[@name='categoryId']");


        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => _driver.FindElementByXPath("//select[@name='subcategoryId']");


        //Enter Tag names in textbox
        private IWebElement Tags => _driver.FindElementByXPath("(//input[@aria-label='Add new tag'])[1]");


        //Select the Service type (Hourly basis service)
        private IWebElement Hourlybasisservice => _driver.FindElementByXPath("//input[@name='serviceType' and @value='0']");


        //Select the Service type (One-off service)
        private IWebElement Oneoffservice => _driver.FindElementByXPath("//input[@name='serviceType' and @value='1']");


        //Select the Location Type
        private IWebElement LocationTypeOptions => _driver.FindElementByXPath("//input[@name='locationType' and @value='0']");


        //Click on Start Date dropdown
        private IWebElement DateStartDropDown => _driver.FindElementByXPath("//input[@name='startDate']");

        //Click on End Date dropdown
        private IWebElement EnddateDropDown => _driver.FindElementByXPath("//input[@name='endDate']");

        //Storing the table of available days
        private IWebElement Days => _driver.FindElementByXPath("//div[@class='ui checkbox'] /input[@index='1']");


        //Click on StartTime dropdown
        private IWebElement StartTimeDropDown => _driver.FindElementByXPath("//input[@name='StartTime' and @index='1']");
     
        //Click on EndTime dropdown
        private IWebElement EndTimeDropDown => _driver.FindElementByXPath("//input[@name='EndTime' and @index='1']");
        

        //Click on Skill Trade option
        private IWebElement SkillTradeOption => _driver.FindElementByXPath("//input[@name='skillTrades' and  @value='true']");
        
        //Click On Skill-Exchange option
        private IWebElement SkillExchangeOption => _driver.FindElementByXPath("//div[@class='form-wrapper'] //input[@aria-label='Add new tag']");
       

        //Enter the amount for Credit
        private IWebElement CreditAmount => _driver.FindElementByXPath("//input[@name='charge']");
        

        //Click on Active/Hidden option
        private IWebElement ActiveOption => _driver.FindElementByXPath("//input[@name='isActive' and @value='true']");
  
        //Click on Save button
        private IWebElement Save => _driver.FindElementByXPath("//input[@value='Save']");
        

        //Click on Cancel button
        private IWebElement Cancel => _driver.FindElementByXPath("//input[@value='Cancel']");
       
        //Click on WorkSample Upload button
        private IWebElement WorkSampleUploadButton => _driver.FindElementByXPath("//i[@class='huge plus circle icon padding-25']");
       

        /*internal void EnterShareSkill()
        {

        }*/

        internal void ClickOnShareSkillButton()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(2000);


                //Click on ShareSkill Button
                ShareSkillButton.Click();

                // Get current URL and store in a variable
                String ShareSkillCurrentUrl = GlobalDefinitions.driver.Url;

                // Print in Console
                Console.WriteLine(ShareSkillCurrentUrl);

                GlobalDefinitions.wait(2000);

                // Validate if user had navigated to Share skills page successfully
                if (ShareSkillCurrentUrl == "http://192.168.99.100:5000/Home/ServiceListing")

                {
                    // Print in Console
                    Console.WriteLine("Passed - Search skills button takes user to search skills page succesfully");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigated to Search skills page ");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - search skills button not taken user to search skills page");


                    //take screen shot and save with given name
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "search skill button");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigating to search skills page - Failed ");
                }

            }
            catch (Exception e)
            {
                // Catch block 
                Base.test.Log(LogStatus.Info, "search skills - Test Failed ", e.Message);

            }
            
            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked ShareSkill Button");
        }

        internal void EnterTitle()
        {
            //populate Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Share_Skill");

            // Enter Title Field
            GlobalDefinitions.wait(5000);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Write in console
            Console.WriteLine("Entered Title");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Title");
        }


        internal void EnterDescription()
        {
            // Enter the Description in textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Write in console
            Console.WriteLine("Entered description");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Description");
        }


        internal void SelectCategoryDropDown()
        {
            /* Click on Category Dropdown
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Graphics & Design")); */

            /* create select element object & select Catagory dropdown
            SelectElement SelectACatagory = new SelectElement(CategoryDropDown);
            SelectACatagory.SelectByText("Graphics & Design"); */

           // create select element object & select Catagory dropdown 
           SelectElement SelectACatagory = new SelectElement(CategoryDropDown);
            foreach (IWebElement element in SelectACatagory.Options)
            {
                if (element.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    element.Click();
                }
            }

            //Write in console
            Console.WriteLine("selected catagory dropdown");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Catagory Dropdown");
        }


        internal void SelectSubCategoryDropDown()
        {

            /* create select element object & select sub Category Dropdown
            SelectElement SelectASubCatagory = new SelectElement(SubCategoryDropDown);
            SelectASubCatagory.SelectByText("Flyers & Brochures"); */ 


            //create select element object & select sub Category Dropdown
            SelectElement SelectASubCatagory = new SelectElement(SubCategoryDropDown);
            foreach (IWebElement element in SelectASubCatagory.Options)
            {
                if (element.Text == GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"))
                {
                    element.Click();
                }
            }

            //Write in console
            Console.WriteLine("selected subcatagory dropdown");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Sub Catagory Dropdown");
        }


        internal void SelectTags()
        {
            //Using for loop to enter multiple tags - from excel file
            for (int i = 2; i <10 ; i++)
            {
                Actions action = new Actions(GlobalDefinitions.driver);
                action.MoveToElement(Tags).Click().Perform();
                string TagsDataFromExcel =  GlobalDefinitions.ExcelLib.ReadData(i, "Tags");
                if (TagsDataFromExcel != null)
                {
                    Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Tags"));
                    Tags.SendKeys(Keys.Enter);
                }

            }
            //Write in console
            Console.WriteLine("Entered tags");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered All the tags");
        }


        internal void SelectServiceTypeOptions()
        {
            //Select the Service type
            //Hourlybasisservice.Click();

           //Using if condition to take service type data from excel file
             if (GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']")).Text.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Service Type")))
                 {
                     Hourlybasisservice.Click();
                 }
                else
                 {
                     Oneoffservice.Click();
                 }

            //Write in console
            Console.WriteLine("selected service type");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Service Type");

            
        }


        internal void SelectLocationTypeOptions()
        {
            ////Select the Location type
            LocationTypeOptions.Click();

            //Write in console
            Console.WriteLine("selected location type");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected LOcation Type");
        }


        internal void SelectStartDateDropDown()
        {

            //Find the date time picker control and Fill date as dd/mm/yyyy as 30/03/2020
            DateStartDropDown.SendKeys("30302050");
            //DateStartDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Startdate"));

            //Write in console
            Console.WriteLine("Entered startdate");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Startdate");
        }


        internal void SelectEndDateDropDown()
        {
            //Find the date time picker control and Fill date as dd/mm/yyyy as 30/03/2050
            EnddateDropDown.SendKeys("30032060");
            //EnddateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Enddate"));

            //Write in console
            Console.WriteLine("Entered enddate");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Enddate");
        }

        internal void SelectDays()
        {
            //Click On available days
            Days.Click();

            //Write in console
            Console.WriteLine("selected available days");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Available days");
        }

        internal void SelectStartTimeDropDown()
        {
            //Click on StartTime dropdown
            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));

            //Write in console
            Console.WriteLine("Entered starttime");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered StartTime");

        }


        internal void SelectEndTimeDropDown()
        {
            // Click On EndTime Dropdown
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            //Write in console
            Console.WriteLine("Entered endtime");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered EndTime");
        }

        internal void SelectSkillTradeOption()
        {
            //Click on Skill Trade option
            SkillTradeOption.Click();

            //Write in console
            Console.WriteLine("selected skilltrade option");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected SkillTrade Option");
        }


        internal void SelectSkillExchangeOption()
        {
            // To mouse hover Skill Exchange Option using Actions
            Actions action1 = new Actions(GlobalDefinitions.driver);
            action1.MoveToElement(SkillExchangeOption).Click().Perform();

            //Read Skill exchange data from excel file
            SkillExchangeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));

            //Pressing the enter key 
            SkillExchangeOption.SendKeys(Keys.Enter);

            //Write in console
            Console.WriteLine("Selected skill exchange option");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Skill Exchange Option");

        }

        internal void SelectActiveOption()
        {
            //Click on Active/Hidden option
            ActiveOption.Click();

            //Write in console
            Console.WriteLine("checked active option");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Checked Active Option");
        }



        internal void UploadWorkSamplesAutoIt()
        {

            // Click on Work Sample file upload button
            WorkSampleUploadButton.Click();


            // AutoIt - Handles windows that do not belongs to browser
            AutoItX3 autoIt = new AutoItX3();

            ////To activate the window("open" is the window name for chrome. if u click upload file button from mozilla or IE, the window name is different
            autoIt.WinActivate("Open");  // https://www.youtube.com/watch?v=vmWmCw_8WsE

            //defining driver wait
            GlobalDefinitions.wait(2000);
            Thread.Sleep(2000);

            // To Select file from a window 
            autoIt.Send(@"F:\Tasks\fileuploadsample.txt");

            //defining driver wait
            GlobalDefinitions.wait(2000);
            
            // To press open button -- so the file will get uploaded
            autoIt.Send("{ENTER}");

            //Write in console
            Console.WriteLine("work sample file uploaded");

            //Write log reports
            Base.test.Log(LogStatus.Info, "WorkSample File Uploaded");

        }


        internal void ClickSave()
        {
            // Click On Save Button
            Save.Click();

            //Write in console
            Console.WriteLine("Clicked save");

            //Write log reports
            Base.test.Log(LogStatus.Info, "Clicked Save");
        }
    }
}
