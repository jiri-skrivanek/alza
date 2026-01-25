using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class ExampleTest : BaseTest
{
    [Test]
    public void HomePageTest()
    {
        HomePage homePage = new HomePage();
        homePage.Open();
        homePage.AddToBasketFirstProductFromCategory("Electronics");
    }
}
