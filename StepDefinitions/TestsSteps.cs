using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace EPAM_testy
{
    [Binding]
    public class MySteps : PageObjects
    {
        private SeleniumContext sel;
        public MySteps(SeleniumContext seleniumContext)
        {
            this.sel = seleniumContext;
        }

        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            sel.Driver.Navigate().GoToUrl(homepage);
            AcceptPrivacySettings();
        }

        [When(@"I click change language button")]
        public void WhenIClickChangeLanguageButton()
        {

            sel.Click(ChangeLanguageButton);
            AcceptPrivacySettings();
        }

        [Then(@"I should see text ""(.*)"" on page")]
        public void ThenIShouldSeeTextOnPage(string p0)
        {
            new WebDriverWait(sel.Driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.TextToBePresentInElement(sel.Driver.FindElement(By.TagName("body")), p0));
        }

        [Then(@"I should see text ""(.*)"" in search results")]
        public void ThenIShouldSeeTextInSearchResults(string p0)
        {
            IWebElement SearchResultsDiv = sel.Driver.FindElement(SearchResults);
            Assert.IsTrue(SearchResultsDiv.Text.Contains(p0));
            //new WebDriverWait(sel.Driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.TextToBePresentInElement(sel.Driver.FindElement(SearchResults), p0));
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string p0)
        {
            sel.Click(SearchButton);
            sel.SendKeys(SearchField, p0);
            sel.SendKeys(SearchField, Keys.Enter);
            sel.Driver.SwitchTo().DefaultContent();
        }

        [When(@"I change domicile to United Kingdom")]
        public void WhenIChangeDomicileToUnitedKingdom()
        {
            sel.Click(ChangeDomicileButton);
            sel.Click(ContinentDropdown);
            sel.Click(ContinentEuropeOption);
            sel.Click(DomicileDropdown);
            sel.Click(DomicileUnitedKingdomOption);

        }
        [Then(@"The page should change to UK Version")]
        public void ThenThePageShouldChangeToUKVersion()
        {
            new WebDriverWait(sel.Driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.TextToBePresentInElement(sel.Driver.FindElement(By.XPath("//div/span/span")), "United Kingdom"));
            String currentURL = sel.Driver.Url;
            Assert.AreEqual(currentURL, "https://www.ubs.com/uk/en.html");
        }

        public void AcceptPrivacySettings()
        {
            try
            {
                sel.Driver.SwitchTo().Frame(0);
                sel.Click(AcceptPrivacySettingsButton);
                sel.Driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                sel.Driver.SwitchTo().DefaultContent();
            }
        }
    }
}
