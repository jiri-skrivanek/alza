using UI.Template.Models;

namespace UI.Template.Data;

public static class TestData
{
    public static TestProduct ParametersTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Wireless Mouse",
        ProductUrl = "/product/2"
    };

    public static TestProduct CardTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Gaming Keyboard RGB"
    };

    public static TestProduct AdminTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "Camera M25",
        ProductPrice = 50,
        ProductStock = 5,
        ProductImage = "Camera 2"
    };

    public static TestProduct AdminTestProductDefault { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "DSLR Camera X200",
        ProductPrice = 700
    };

    public static TestCustomer AdminTestCustomer { get; } = new TestCustomer
    {
        FirstName = "Joe",
        LastName = "Doe",
        Street = "Pink 1",
        City = "Newtown",
        ZipCode = "12345",
        Email = "joe.doe@a.b.c",
        PhoneNumber = "123456789",
        PaymentMethod = "PayPal"
    };
}
