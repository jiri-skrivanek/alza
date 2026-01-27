using UI.Template.Components.Containers;
using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class AdminTest : BaseTest
{
    [Test]
    public void AddNewProductTest()
    {
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
        // TODO - can be removed when description is not required (bug #12345)
        editProductContainer.SetDescription("Dummy");
        // save
        editProductContainer.SaveChanges();
        // switch back to shop
        homePage = adminPage.GoToEshopHome();
        // switch to category and open product
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(TestData.AdminTestProduct.ProductCategory, TestData.AdminTestProduct.ProductName);
        // get product info
        Product productModel = productDetail.ProductInfoForm.ToProductModel();
        // compare expected values
        Assert.Multiple(() =>
        {
            Assert.That(productModel.Name, Is.EqualTo(TestData.AdminTestProduct.ProductName), "Wrong product name");
            Assert.That(productModel.Price, Is.EqualTo(TestData.AdminTestProduct.ProductPrice), "Wrong product price");
            Assert.That(productModel.Stock, Is.EqualTo(TestData.AdminTestProduct.ProductStock), "Wrong product availability");
        });
    }
}
