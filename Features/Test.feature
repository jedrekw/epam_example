Feature: Example UBS tests

	Scenario: Change page language to Deutsch
		Given I am on homepage
		When I click change language button
		Then I should see text "Globale Themen" on page
		And I should see text "Dienstleistungen in Ihrer Region" on page
		And I should see text "Investment Views und Finanzmarktdaten" on page

	Scenario: Check search function
		Given I am on homepage
		When I search for "invest"
		Then I should see text "invest" in search results

	Scenario: Check changing domicile
		Given I am on homepage
		When I change domicile to United Kingdom
		Then The page should change to UK Version
