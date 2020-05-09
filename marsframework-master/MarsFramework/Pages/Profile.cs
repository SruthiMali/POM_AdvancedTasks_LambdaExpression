using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://www.youtube.com/watch?v=jgKgbVcQ-1U&feature=youtu.be for lambda expressions

namespace MarsFramework.Pages
{
    class Profile
    {
        //Creating a constructor
        private readonly RemoteWebDriver _driver;
        public Profile()
        {
            _driver = GlobalDefinitions.driver;
        }


        //Click Desctiption Icon 
        private IWebElement Description => _driver.FindElementByXPath("//h3[contains(.,'Description')]/span");


        //Enter Description 
        private IWebElement EnterDescription => _driver.FindElementByXPath("//textarea[@maxlength='600']");


        //Click on Save Button to save description
        private IWebElement DescriptionSave => _driver.FindElementByXPath("//button[@type='button']");


        //Click on username/Hi Sruthi
        private IWebElement Username => _driver.FindElementByXPath("//span[contains(.,'Hi Sruthi')]");


        //Click Change Password
        private IWebElement ChangePassword => _driver.FindElementByXPath("//a[contains(text(),'Change Password')]");


        // Click on current password 
        private IWebElement CurrentPassword => _driver.FindElementByXPath("//input[@name='oldPassword']");


        // Click on New password 
        private IWebElement NewPassword => _driver.FindElementByXPath("//input[@name='newPassword']");

        // Click on Confirm password 
        private IWebElement ConfirmPassword => _driver.FindElementByXPath("//input[@name='confirmPassword']");


        // Click on Change password save button
        private IWebElement ChangePasswordSave => _driver.FindElementByXPath("//button[@type='button'][contains(.,'Save')]");
        

        internal void AddDescription()
        {
            try
            {
                Thread.Sleep(2000);

                // Click on Description Icon 
                Description.Click();
                GlobalDefinitions.wait(5000);

                // Enter Description
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.SendKeys("Hi Sruthi");

                GlobalDefinitions.wait(2000);

                //Click on Save button
                DescriptionSave.Click();

                // Validate if user added description successfully
                string ExpectedValue = "Description has been saved successfully";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                // Assert Condition for adding description Confirmation message
                if (ExpectedValue == ActualValue)
                {
                    // Print in Console
                    Console.WriteLine("Passed - user added description successfully");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - user not added description");
                }

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user added description successfully");

            }
            catch (Exception e)
            {

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "user not added description");

                // write log reports
                Base.test.Log(LogStatus.Info, "Adding Description -Test Failed", e.Message);
            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked Add Description Icon");

        }

        internal void EditDescription()
        {
            try
            {
                Thread.Sleep(2000);

                // Click on Description Icon 
                Description.Click();

                GlobalDefinitions.wait(9000);

                // Enter Description
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.Clear();
                EnterDescription.SendKeys("Hi Sruthi");

                GlobalDefinitions.wait(2000);

                //Click on Save button
                DescriptionSave.Click();

                GlobalDefinitions.wait(2000);

                // Validate if user edited description successfully
                // Validate if user added description successfully
                string ExpectedValue = "Description has been saved successfully";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;


                // Assert Condition for adding description Confirmation message
                if(ExpectedValue == ActualValue)
                {
                    // Print in Console
                    Console.WriteLine("Passed - user edited description successfully");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - user not edited description");
                }

                

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user edited description successfully");

            }
            catch (Exception e)
            {
                

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "user not edited description");

                // write log reports
                Base.test.Log(LogStatus.Info, "Editing description -Test Failed", e.Message);
            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked edit Description Icon");

        }

        internal void ClickChangePassword()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(5000);

                // To mouse hover username/Hi Sruthi link using Actions & click change password
               // Actions action2 = new Actions(GlobalDefinitions.driver);
               // action2.MoveToElement(Username).MoveToElement(ChangePassword).Click().Build().Perform();

                //Click on Username & select Change Password  by using Actions 
                Username.Click();

                // using for loop to click down arrow for 2 times
                for (int i=0; i<2; i++)
                {
                    
                    Username.SendKeys(Keys.ArrowDown);
                }

                // Click on Change Password
               ChangePassword.Click();

                //Populate the excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

                // Enter current password 
                CurrentPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

               // Enter New password 
                NewPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

                //Enter Confirm Password
                ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

               // Click on Change password save button
                ChangePasswordSave.Click();

                // Print in Console
                Console.WriteLine("Passed - user able to change password ");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user able to change password successfully");

            }
            catch (Exception e)
            {
                // Print in Console
                Console.WriteLine("Failed - user unable to change password ");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Change password");

                // write log reports
                Base.test.Log(LogStatus.Info, "Change password -Test Failed", e.Message);

            }
        }

    }
}
