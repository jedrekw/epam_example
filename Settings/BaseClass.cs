using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace EPAM_testy
{ 
[Binding]
    public class SeleniumContext
    {
        public void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public void SendKeys(By locator, string value)
        {
            Driver.FindElement(locator).SendKeys(value);
        }
        

        public SeleniumContext()
        {
            Driver = new FirefoxDriver("C:\\Users\\jedrekw\\.nuget\\packages\\selenium.webdriver.geckodriver\\0.26.0.1\\driver\\win64");
        }

        public IWebDriver Driver { get; private set; }
    }


    }
