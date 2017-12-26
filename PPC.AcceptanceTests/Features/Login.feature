@login
Feature: Login
	As a owner of property
	I want to login to website
	So that i can manage my property 

Background:
	Given the following account
	| Email                    | Password | FullName | Phone      | Address       | Role | Status |
	| lythihuyenchau@gmail.com | 123456   | Ly Chau | 0999580654 | Trần Hưng Đạo | 1    | True   |
	| sonnguyen@gmail.com      | 123456   | son      | 09999999   | Trần Hưng Đạo | 2    | True   |

Scenario: Login successfully
	When I am at Home Page
	And I have navigate to Login Page
	And I entered 'lythihuyenchau@gmail.com' and '123456'