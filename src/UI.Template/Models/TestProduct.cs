namespace UI.Template.Models;

public class TestProduct
{
    public string ProductCategory { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string ProductUrl { get; set; } = string.Empty;
    public int ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public string ProductImage { get; set; } = string.Empty;
}

public class TestCustomer
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
}
