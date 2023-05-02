using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task.Pages;

namespace Task.StepDefinitions
{
    [Binding]
    public sealed class AddItemsToCartStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage _homePage;
        private IWebElement lowestElement;
        //private readonly ProductPage _productPage;

        public AddItemsToCartStepDefinitions(ScenarioContext scenarioContext) //, HomePage homePage //, ProductPage productPage
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(new ChromeDriver());
            //_productPage = productPage;
        }

        [Given(@"I add (.*) random items to my cart")]
        public void GivenIAddRandomItemsToMyCart(int numberOfItems)
        {
            _homePage.Go();
            _homePage.AddRandomItemsToCart(numberOfItems);
        }


        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _homePage.Clickcart();
        }

        [Then(@"I find total (.*) items listed in my cart")]
        public void ThenIFindTotalItemsListedInMyCart(int numberOfItems)
        {
           Assert.True(numberOfItems ==  _homePage.GetTotalCartItem(), $"expected {numberOfItems} but got {_homePage.GetTotalCartItem()}");
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            lowestElement = _homePage.GetLowestPriceItem();
        }


        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            lowestElement.Click();
        }

        [Then(@"I am able to verify (.*) items in my cart")]
        public void ThenIAmAbleToVerifyItemsInMyCart(int numberOfItems)
        {
            Assert.True(numberOfItems == _homePage.GetTotalCartItem(), $"expected {numberOfItems} but got {_homePage.GetTotalCartItem()}");
        }


        //[Given("the second number is (.*)")]
        //public void GivenTheSecondNumberIs(int number)
        //{
        //    //TODO: implement arrange (precondition) logic

        //    //throw new PendingStepException();
        //}

        //[When("the two numbers are added")]
        //public void WhenTheTwoNumbersAreAdded()
        //{
        //    //TODO: implement act (action) logic

        //    //throw new PendingStepException();
        //}

        //[Then("the result should be (.*)")]
        //public void ThenTheResultShouldBe(int result)
        //{
        //    //TODO: implement assert (verification) logic

        //    //throw new PendingStepException();
        //}
    }
}