namespace TechTalk.SpecFlow.IntegrationTests.Features
{
    public partial class ReusableScenarioFeature
    {
        public ReusableScenarioFeature(ITestRunner runner)
        {
            testRunner = new NestedTestRunner(runner);
        }
    }
}
