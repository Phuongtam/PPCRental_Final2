@automated5
Feature: UC4_About
	As a user
	I want to see information about company
Background: 
Given Information about company following :
| Content                                                                                                                                                                                                 | create_user      | image                   |
| Perfect Property Company (PPC) is known as a professional enterprise operating in the field of real estate brokerage and marketing both domestically and internationally. PPC focuses on two main areas | luanho@gmail.com | PIS_7432-Edit-stamp.jpg |  

Scenario: About
	When I press the button 'About' about in menu bar
	Then the result should show information about company :
	| Content                                                                                                                                                                                                 | image                   |
	| Perfect Property Company (PPC) is known as a professional enterprise operating in the field of real estate brokerage and marketing both domestically and internationally. PPC focuses on two main areas | PIS_7432-Edit-stamp.jpg |
