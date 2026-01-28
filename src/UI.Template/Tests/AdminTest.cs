using UI.Template.Components.Containers;
using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class AdminTest : BaseTest
{
    [Test]
    public void AddNewProductAndCheckoutTest()
    {
        /*** Add new product ***/
        // open home page
        HomePage homePage = new HomePage();
        homePage.Open();
        homePage.WaitForReady();
        // switch to admin page
        AdminPage adminPage = homePage.Header.OpenAdminPage();
        // open "Add New Product" dialog
        EditProductContainer editProductContainer = adminPage.OpenAddNewProductContainer();
        // fill in values
        editProductContainer.SetName(TestData.AdminTestProduct.ProductName);
        editProductContainer.SelectCategory(TestData.AdminTestProduct.ProductCategory);
        editProductContainer.SetPrice(TestData.AdminTestProduct.ProductPrice);
        editProductContainer.SetStock(TestData.AdminTestProduct.ProductStock);
        editProductContainer.SelectImage(TestData.AdminTestProduct.ProductImage);
        // TODO - can be removed when description is not required (https://github.com/jiri-skrivanek/alza/issues/7)
        editProductContainer.SetDescription("Dummy");
        // save
        editProductContainer.SaveChanges();
        // switch back to shop
        homePage = adminPage.GoToEshopHome();
        // switch to category and open product
        ProductDetailPage productDetailPage = homePage.OpenProductByNameFromCategory(TestData.AdminTestProduct.ProductCategory, TestData.AdminTestProduct.ProductName);
        // get product info
        Product productModel = productDetailPage.ProductInfoForm.ToProductModel();
        // compare expected values
        Assert.Multiple(() =>
        {
            Assert.That(productModel.Name, Is.EqualTo(TestData.AdminTestProduct.ProductName), "Wrong product name");
            Assert.That(productModel.Price, Is.EqualTo(TestData.AdminTestProduct.ProductPrice), "Wrong product price");
            Assert.That(productModel.Stock, Is.EqualTo(TestData.AdminTestProduct.ProductStock), "Wrong product availability");
        });

        /*** Add product to cart and checkout ***/
        // return back to home page
        homePage = new HomePage();
        homePage.Open();
        homePage.WaitForReady();
        // add product to cart
        // TODO - use TestData.AdminTestProduct when it is clarified why only default products can be bought (https://github.com/jiri-skrivanek/alza/issues/8)
        // TestProduct testProduct = TestData.AdminTestProduct;
        TestProduct testProduct = TestData.AdminTestProductDefault;
        homePage.AddToBasketProductFromCategory(testProduct.ProductCategory, testProduct.ProductName);
        // open cart
        homePage.Header.OpenBasketContainer();
        // check name, price and count
        List<string> productNames = homePage.Header.GetProductNamesInBasket();
        Assert.That(productNames.Count, Is.EqualTo(1), "Wrong product count in cart");
        Assert.That(homePage.Header.GetNthProduct(1, out string productName, out string productDetail), Is.True, "First product not found.");
        Assert.That(productName, Is.EqualTo(testProduct.ProductName), "Wrong product in cart");
        Assert.That(productDetail, Is.EqualTo($"$ {testProduct.ProductPrice}.00 × 1"), "Wrong price or count");
        // click Checkout
        CheckoutPage checkoutPage = homePage.Header.Checkout();
        // fill customer data in checkout form
        checkoutPage.FillRequiredFields(TestData.AdminTestCustomer);
        // finish order
        checkoutPage.ClickPay();
        // verify payment method and total value
        checkoutPage.VerifyPaymentAndTotal(TestData.AdminTestCustomer.PaymentMethod, testProduct.ProductPrice);
    }
}
