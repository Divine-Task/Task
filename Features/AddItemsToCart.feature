﻿Feature: Add items to cart

@mytag
Scenario: Add items to cart
	Given I add 4 random items to my cart
	When I view my cart
    Then I find total 4 items listed in my cart
    When I search for lowest price item
	And I am able to remove the lowest price item from my cart
   Then I am able to verify 3 items in my cart