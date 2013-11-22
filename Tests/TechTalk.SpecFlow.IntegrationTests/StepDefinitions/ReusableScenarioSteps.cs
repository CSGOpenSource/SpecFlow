using System;
using NUnit.Framework;
using TechTalk.SpecFlow.IntegrationTests.Features;

namespace TechTalk.SpecFlow.IntegrationTests.StepDefinitions
{
    [Binding]
    public class ReusableScenarioSteps
    {
        private readonly ReusableScenarioFeature _reusableScenario;

        public ReusableScenarioSteps(ReusableScenarioFeature reusableScenario)
        {
            _reusableScenario = reusableScenario;
        }

        [Given(@"I execute a reusable scenario")]
        [When(@"I execute a reusable scenario")]
        [Then(@"I execute a reusable scenario")]
        public void DoStuffAndThings()
        {
            _reusableScenario.DoStuffAndThings();
        }

        [Given(@"I call steps on a shared step binding")]
        [When(@"I call steps on a shared step binding")]
        [Then(@"I call steps on a shared step binding")]
        public void CallStepsOnASharedStepBinding()
        {
            _reusableScenario.CallStepsOnASharedStepBinding();
        }

        [Given(@"I execute a reusable scenario ending with when")]
        public void GivenIExecuteAReusableScenarioEndingWithWhen()
        {
            _reusableScenario.ExecuteAReusableScenarioEndingWithWhen();
        }
    }

    [Binding]
    public class CommonReusableScenarioSteps
    {
        private readonly RandomSteps _randomSteps;
        private const string TestKey = "Test";
        private const string TestValue = "Magical Test Value";

        [Given(@"I do stuff and things")]
        public void GivenIDoStuffAndThings()
        {
            Console.WriteLine("Do stuff AND things!");
        }

        [Given(@"I store a value in the Scenario Context")]
        public void StoreATestValueInTheScenarioContext()
        {
            ScenarioContext.Current.Add(TestKey, TestValue);
        }

        [Then(@"The value in the Scenario Context should still be stored")]
        public void AssertScenarioContextContainsTestValue()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(TestKey));
            Assert.AreEqual(ScenarioContext.Current.Get<string>(TestKey), TestValue);
        }

        [When(@"I call a when step")]
        public void CallAWhenStep()
        {
        }

        [Given(@"I call a given step")]
        public void CallAGivenStep()
        {
        }

    }

    [Binding]
    public class RandomSteps
    {
        public const string ExpectedRandomStepArgument = "Set at runtime!";

        public string RandomStepArgument;

        [Given(@"I call a random step that stores a value on the step binding")]
        public void CallRandomStep()
        {
            RandomStepArgument = ExpectedRandomStepArgument;
        }
    }

    [Binding]
    public class StepsThatDirectlyUseAReusableScenario
    {
        private readonly ReusableScenarioSteps _reusableScenarioSteps;
        private readonly RandomSteps _randomSteps;

        public StepsThatDirectlyUseAReusableScenario(ReusableScenarioSteps reusableScenarioSteps, RandomSteps randomSteps)
        {
            _reusableScenarioSteps = reusableScenarioSteps;
            _randomSteps = randomSteps;
        }

        [When("I call a step that uses an injected reusable scenario")]
        public void CallReusableScenarioAndThenUseInjectedStepsCreatedByTheReusableScenario()
        {
            _reusableScenarioSteps.CallStepsOnASharedStepBinding();
        }

        [Then("The injected random steps should contain the data populated by the reusable scenario")]
        public void AssertRandomStepsContainsDataPopulatedByReusableScenario()
        {
            Assert.AreEqual(RandomSteps.ExpectedRandomStepArgument, _randomSteps.RandomStepArgument);            
        }
    }
}
