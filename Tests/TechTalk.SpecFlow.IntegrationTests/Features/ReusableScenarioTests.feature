Feature: ReusableScenarioTests
	
Scenario: Execute a reusable scenario
	Given I store a value in the Scenario Context
	When I execute a reusable scenario
	Then The value in the Scenario Context should still be stored

Scenario: Use an injected reusable feature
	When I call a step that uses an injected reusable scenario
	Then The injected random steps should contain the data populated by the reusable scenario
	Then I execute a reusable scenario
	Then I call steps on a shared step binding

Scenario: Execute a reusable scenario that ends with a When then call a given
	Given I execute a reusable scenario ending with when
	And I call a given step