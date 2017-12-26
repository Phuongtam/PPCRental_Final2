Feature: TC3_ViewListOfProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: I want to see the list of project on the screen
	Given I have enter the homepage
	And I have click login
	When I entered username and password
	And click submit
	Then the result should show the list of project on the screen
