using OpenQA.Selenium;
using UI.Template.Components;
using UI.Template.Components.Containers;
using UI.Template.Framework.Extensions;

namespace UI.Template.Pages;

public class HomePage() : BaseEshopPage("/")
{
    private readonly CategoryContainer _categories = new CategoryContainer(By.XPath("//*[@class='categories-sidebar']"));
    private readonly ProductGridContainer _productsGrid = new ProductGridContainer(By.XPath("//*[@class='products-grid']"));

    /// <summary>
    /// Adds the first product from a specific category to the basket and waits for basket updated.
    /// At least one product in category is expected otherwise it fails on assertion error.
    /// </summary>
    /// <param name="category">The name of the category.</param>
    /// <exception cref="WebDriverTimeoutException">
    /// Thrown when the basket is not updated.
    public void AddToBasketFirstProductFromCategory(string category)
    {
        AddToBasketProductFromCategory(category);
    }

    /// <summary>
    /// Opens a product detail page by its name from a specific category.
    /// </summary>
    /// <param name="category">The name of the category.</param>
    /// <param name="product">The name of the product.</param>
    /// <returns></returns>
    public ProductDetailPage OpenProductByNameFromCategory(string category, string product)
    {
        _categories.SelectCategory(category);
        return GetProductCard(product).OpenProductDetail();
    }

    /// <summary>
    /// Tries to find a product card by its name on the current category.
    /// </summary>
    /// <param name="productName"></param>
    /// <param name="productCard"></param>
    /// <returns></returns>
    public bool TryGetProductCardByName(string productName, out ProductCard productCard)
    {
        Dictionary<string, ProductCard> productCards = _productsGrid.GetProductCards();

        if (!productCards.TryGetValue(productName, out ProductCard? value))
        {
            productCard = null!;
            return false;
        }

        productCard = value;
        return true;
    }

    /// <summary>
    /// Returns the name of the currently selected category.
    /// </summary>
    /// <returns></returns>
    public string GetCurrentCategory()
    {
        return _categories.GetCurrentCategory();
    }

    /// Adds the product from a specific category to the basket and waits for basket updated.
    /// </summary>
    /// <param name="category">The name of the category.</param>
    /// <param name="product">The name of the product.</param>
    /// <exception cref="WebDriverTimeoutException">
    /// Thrown when the basket is not updated.
    public void AddToBasketProductFromCategory(string category, string product = "")
    {
        int basketCountBefore = Header.GetBasketCount();
        _categories.SelectCategory(category);
        GetProductCard(product).AddToBasket();

        Wait.SetTimeoutMessage($"Basket should have '{basketCountBefore + 1}' items.")
            .Until(_ => Header.GetBasketCount() == basketCountBefore + 1);
    }

    /// <summary>
    /// Returns a product card by its name on the current category.
    /// </summary>
    /// <param name="productName">The name of the product.</param>
    /// <returns>Product card</returns>
    /// <exception cref="NoSuchElementException">Thrown when the product not found.</exception>
    private ProductCard GetProductCard(string productName = "")
    {
        Dictionary<string, ProductCard> productCards = _productsGrid.GetProductCards();

        if (string.IsNullOrEmpty(productName))
        {
            return productCards.First().Value;
        }
        else
        {
            if (!productCards.TryGetValue(productName, out ProductCard? productCard))
            {
                throw new NoSuchElementException("Product \"" + productName + "\" not found.");
            }
            return productCard;
        }
    }
}
