Feature: Reusable Scenario

Scenario: Do Stuff and Things
	Given I do stuff and things
	
Scenario: Call steps on a shared step binding
	Given I call a random step that stores a value on the step binding

Scenario: Execute a reusable scenario ending with when
	When I call a when step
