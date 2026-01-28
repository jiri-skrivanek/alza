using OpenQA.Selenium;
using UI.Template.Components;
using UI.Template.Models;

namespace UI.Template.Pages;

public class CheckoutPage() : BasePage("/checkout")
{
    private readonly CheckoutForm _checkoutForm = new CheckoutForm(By.XPath("//*[@class='checkout-form']"));
    private readonly OrderConfirmation _orderConfirmation = new OrderConfirmation(By.XPath("//*[@class='order-confirmation']"));

    /// <summary>
    /// Fills all required values in checkout form.
    /// </summary>
    /// <param name="customer">The customer data.</param>
    public void FillRequiredFields(TestCustomer customer)
    {
        _checkoutForm.SetFirstName(customer.FirstName);
        _checkoutForm.SetLastName(customer.LastName);
        _checkoutForm.SetStreet(customer.Street);
        _checkoutForm.SetCity(customer.City);
        _checkoutForm.SetZipCode(customer.ZipCode);
        _checkoutForm.SetEmail(customer.Email);
        _checkoutForm.SetPhoneNumber(customer.PhoneNumber);
        _checkoutForm.SelectPaymentMethod(customer.PaymentMethod);
    }

    /// <summary>
    /// Clicks the Pay button.
    /// </summary>
    public void ClickPay()
    {
        _checkoutForm.ClickPay();
    }

    /// <summary>
    /// Watis for expected payment method and total value.
    /// <param name="paymentMethod">The payment method.</param>
    /// <param name="total">The total value.</param>
    /// </summary>
    public void VerifyPaymentAndTotal(string paymentMethod, decimal total)
    {
        _orderConfirmation.WaitForPaymentMethod(paymentMethod);
        _orderConfirmation.WaitForTotal(total);
    }
}
