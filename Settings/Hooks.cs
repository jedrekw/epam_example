
using TechTalk.SpecFlow;
using BoDi;

namespace EPAM_testy
{

    [Binding]
    public class BeforeAllTests
    {
        private readonly IObjectContainer objectContainer;
        private static SeleniumContext seleniumContext;

        public BeforeAllTests(IObjectContainer container)
        {
            this.objectContainer = container;
        }

        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            seleniumContext = new SeleniumContext();
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            seleniumContext.Driver.Close();
            //seleniumContext.Driver.Dispose();
        }
    }
}
