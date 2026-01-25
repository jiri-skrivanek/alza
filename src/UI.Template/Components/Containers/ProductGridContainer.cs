using OpenQA.Selenium;
using UI.Template.Framework.Configurations;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components.Containers;

public class ProductGridContainer(By locator) : BaseComponent(locator)
{
    public Dictionary<string, ProductCard> GetProductCards()
    {
        Dictionary<string, ProductCard> productCards = new Dictionary<string, ProductCard>();
        By productCardXPathLocator = By.XPath(Locator.ToSelector() + "//div[@class='product-card']");

        if (!Wait.TryWaitWithCondition(() => WebDriver.FindElements(productCardXPathLocator).Count > 0, timeout: 5))
        {
            Logger.LogWarning("There are no products in the product grid container.");
            return productCards;
        }

        // need to repeat productCard scanning for the case that cards are not yet refreshed after category switch
        Wait.GetCustomWait(TestConfiguration.PageElementTimeout * 2, -1, typeof(WebDriverTimeoutException))
            .SetTimeoutMessage("Product cards not ready.")
            .Until(_ =>
            {
                productCards.Clear();
                int productCardsCount = WebDriver.FindElements(productCardXPathLocator).Count;
                for (int i = 1; i <= productCardsCount; i++)
                {
                    ProductCard productCard = new(By.XPath($"({productCardXPathLocator.ToSelector()})[{i}]"));
                    productCard.ScrollTo();
                    productCards.Add(productCard.GetName(), productCard);
                }
                return true;
            });

        return productCards;
    }
}
