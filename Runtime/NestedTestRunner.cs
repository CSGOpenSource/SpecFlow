using System.Reflection;

namespace TechTalk.SpecFlow
{
    /// <summary>
    /// Test runner which wraps the parent test runner but skips feature/scenario setup/teardown.
    /// Enables calling entire scenarios from a step
    /// </summary>
    public class NestedTestRunner : ITestRunner
    {
        private readonly ITestRunner _testRunner;
        private ScenarioBlock? _parentScenarioBlock;

        public NestedTestRunner(ITestRunner testRunner)
        {
            _testRunner = testRunner;
        }

        private void SaveParentScenarioBlock()
        {
            if (_parentScenarioBlock != null)
                return;

            _parentScenarioBlock = ScenarioContext.CurrentScenarioBlock;
        }

        private void RestoreParentScenarioBlock()
        {
            if (_parentScenarioBlock == null)
                return;

            ScenarioContext.CurrentScenarioBlock = _parentScenarioBlock.Value;
        }

        public ScenarioContext ScenarioContext
        {
            get { return _testRunner.ScenarioContext; }
        }

        public FeatureContext FeatureContext
        {
            get { return _testRunner.FeatureContext; }
        }

        public void Pending()
        {
            _testRunner.Pending();
        }

        public void But(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _testRunner.But(text, multilineTextArg, tableArg, keyword);
        }

        public void And(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _testRunner.And(text, multilineTextArg, tableArg, keyword);
        }

        public void Then(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _testRunner.Then(text, multilineTextArg, tableArg, keyword);
        }

        public void When(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _testRunner.When(text, multilineTextArg, tableArg, keyword);
        }

        public void Given(string text, string multilineTextArg, Table tableArg, string keyword = null)
        {
            _testRunner.Given(text, multilineTextArg, tableArg, keyword);
        }

        public void OnTestRunEnd()
        {
            // Do nothing
        }

        public void OnScenarioEnd()
        {
            // Do nothing
        }

        public void CollectScenarioErrors()
        {
            RestoreParentScenarioBlock();
        }

        public void OnScenarioStart(ScenarioInfo scenarioInfo)
        {
            SaveParentScenarioBlock();
        }

        public void OnFeatureEnd()
        {
            // Do nothing
        }

        public void OnFeatureStart(FeatureInfo featureInfo)
        {
            // Do nothing
        }

        public void InitializeTestRunner(Assembly[] bindingAssemblies)
        {
            // Do nothing
        }
    }
}
