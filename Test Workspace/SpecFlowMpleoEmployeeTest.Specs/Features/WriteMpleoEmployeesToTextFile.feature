Feature: WriteMpleoEmployeesToTextFile

This gets all employees from mpleo.

@tag1
Scenario: Get all employees
	Given a working url is 'https://demoarnohr.mpleo.net/ws/employee'
	When the function GetMpleoEmployeesAsync gets called
	Then the resulting list should not be empty

@tag1
Scenario: Get an empty list of employees
	Given a wrong url is 'https://demoarnohr.mpleo.net/ws2/employee'
	When the function GetMpleoEmployeesAsync gets called
	Then the resulting list should be empty
	