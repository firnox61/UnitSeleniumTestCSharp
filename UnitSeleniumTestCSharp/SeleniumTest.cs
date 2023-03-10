//Inside SeleniumTest.cs

using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

namespace SeleniumCsharp

{

    public class Tests

    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {

            //Below code is to get the drivers folder path dynamically.

            //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            driver = new ChromeDriver(path + @"\drivers\");

            //If you want to Execute Tests on Firefox uncomment the below code

            // Specify Correct location of geckodriver.exe folder path. Ex: C:/Project/drivers

            //driver= new FirefoxDriver(path + @"\drivers\");

        }

        [Test]

        public void verifyLogo()

        {

            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);

        }

        [Test]

        public void verifyMenuItemcount()

        {

            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath("//ul[contains(@class,'horizontal-list product-menu')]/li"));

            Assert.AreEqual(menuItem.Count, 4);

        }

        [Test]

        public void verifyPricingPage()

        {

            driver.Navigate().GoToUrl("https://browserstack.com/pricing");

            IWebElement contactUsPageHeader = driver.FindElement(By.TagName("h1"));

            Assert.IsTrue(contactUsPageHeader.Text.Contains("Real device cloud of 20,000 + real iOS & Android devices, instantly accessible"));

        }
        [Test]
        public void BurganSearchPage()
        {

            driver.Navigate().GoToUrl("https://www.burgan.com.tr/");
            //driver = new ChromeDriver("D:\\3rdparty\\chrome");
            // driver.Url = "https://www.burgan.com.tr/";
            //  driver.Manage().Window.Maximize();
            // IWebElement link = driver.FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
            IWebElement element = driver.FindElement(By.XPath("/html/body/nav[1]/div/div/div[5]/a/span/i")); element.Click();
            IWebElement element1 = driver.FindElement(By.XPath("/html/body/form/div/div/div/input"));
            element1.SendKeys("Yatýrým");
            IWebElement element2 = driver.FindElement(By.XPath("/html/body/form/div/div/div/div/button/i"));
            element2.Submit();
            IWebElement element3 = driver.FindElement(By.XPath("//*[@id=\"main-html-content\"]/section/div/a[4]/h4"));
            element3.Click();
            IWebElement element4 = driver.FindElement(By.XPath("//*[@id=\"sayi1\"]"));
            element4.SendKeys("100");
            /* IWebElement element5 = driver.FindElement(By.XPath("//*[@id=\"section-740001\"]/div/div/div[3]/div/div/div[6]/button"));
             element5.Submit();*/
            //IWebElement element6 = driver.FindElement(By.XPath("document.querySelector(\"#section-740001 > div > div > div:nth-child(3) > div > div > div:nth-child(2) > div > input\")"));

            //IWebElement element7 = driver.FindElement(By.XPath("//*[@id="section - 740001"]/div/div/div[3]/div/div/div[6]/button"));
            IWebElement element7 = driver.FindElement(By.XPath("//*[@id=\"section-740001\"]/div/div/div[3]/div/div/div[6]/button"));// element7.Submit();
            element7.Click();
            //*[@id="section-740001"]/div/div/div[3]/div/div/div[6]/button
            //*[@id="section-740001"]/div/div/div[3]/div/div/div[6]/button
            //String tagName = element6.TagName;
            /*int text = element6.To;
            Console.WriteLine(text);
            IWebelement element = driver.FindElement(By.xpath("xpath of Webelement")); */
        }





        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}
