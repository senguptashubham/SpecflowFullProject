Feature: Login
	This functionality helps to check the login


Scenario: Login with valid credentials		
  	Given User navigates to url "<#url#>"		
	When User enters text "standard_user" in "SauceLabLogin.txtUsername1"
	When User enters text "secret_sauce" in "SauceLabLogin.txtPassword"	
	When User click element "SauceLabLogin.btnLogin" with javascript	

Scenario: Login to application
 Given user login to saucelab application

	Scenario: Login with different user	
	#Given user login to saucelab application
  	Given User navigates to url "<#url#>"		
	When User enters text "standard_user" in "SauceLabLogin.txtUsername"
	When User enters text "secret_sauce" in "SauceLabLogin.txtPassword"	
	When User click element "SauceLabLogin.btnLogin" with javascript

	
	
	
	

	
