Feature: Check out items
	This functionality helps to check the checkout


Scenario: Check out back pack	
  	Given User navigates to url "<#url#>"		
	When User enters text "standard_user" in "SauceLabLogin.txtUsername"
	When User enters text "secret_sauce" in "SauceLabLogin.txtPassword"	
	When User click element "SauceLabLogin.btnLogin" with javascript
	When User waits for "5000"
	When User clicks on "SauceLabLogin.btnSauceLabBackPack"
	When User waits for "2000"
	When User clicks on "SauceLabLogin.lnkSauceLabImage"
