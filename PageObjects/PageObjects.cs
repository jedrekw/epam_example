using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EPAM_testy
{
    [Binding]
    public class PageObjects
    {
        public string homepage = "https://www.ubs.com/global/en.html";

        public By AcceptPrivacySettings = By.CssSelector(".actionbutton__color--standardbuttondark .actionbutton__txtbody");
        public By ChangeLanguageButton = By.LinkText("DE");
        public By SearchButton = By.CssSelector(".headerSearch__toggle");
        public By SearchField = By.Id("pagesearchfield");
        public By SearchResults = By.XPath("//article/div/div/div/div/div/div/div[2]");
        public By ChangeDomicileButton = By.XPath("//button[contains(.,'Select domicile')]");
        public By ContinentDropdown = By.XPath("//button[contains(.,'Domicile')]");
        public By ContinentEuropeOption = By.XPath("//button[contains(.,'Europe')]");
        public By DomicileDropdown = By.XPath("//div/ul/li/ul/li[3]/button");
        public By DomicileUnitedKingdomOption = By.LinkText("United Kingdom");

    }
}
