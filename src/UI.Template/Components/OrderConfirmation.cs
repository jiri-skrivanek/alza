using System.Globalization;
using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components;

public class OrderConfirmation(By locator) : BaseComponent(locator)
{
    private Simple PaymentMethod => new(By.XPath($"{Locator.ToSelector()}//*[@ko-id='order-paymentMethod']"));
    private Simple Total => new(By.XPath($"{Locator.ToSelector()}//*[@ko-id='order-total-value']"));

    /// <summary>
    /// Waits for the expected payment method.
    /// </summary>
    /// <param name="expectedValue">Expected value</param>
    /// <exception cref="WebDriverTimeoutException">
    /// Thrown when expected value was not found.</exception>
    public void WaitForPaymentMethod(string expectedValue)
    {
        Wait.SetTimeoutMessage($"Expected payment method was {expectedValue}")
        .Until(_ => GetPaymentMethod() == expectedValue);
    }

    /// <summary>
    /// Waits for the expected payment method.
    /// </summary>
    /// <param name="expectedValue">Expected value</param>
    /// <exception cref="WebDriverTimeoutException">
    /// Thrown when expected value was not found.</exception>
    public void WaitForTotal(decimal expectedValue)
    {
        Wait.SetTimeoutMessage($"Expected total value was {expectedValue}")
        .Until(_ => GetTotal() == expectedValue);
    }

    /// <summary>
    /// Returns the payment method as parsed from the UI.
    /// </summary>
    /// <returns>Payment method (e.g. "PayPal")</returns>
    public string GetPaymentMethod()
    {
        string text = PaymentMethod.GetText();
        return text.Replace("Payment Method: ", "").Trim();
    }

    /// <summary>
    /// Returns the total value as parsed from the UI.
    /// </summary>
    /// <returns>Total value</returns>
    public decimal GetTotal()
    {
        string text = Total.GetText();
        string cleaned = text.Replace("$", "").Trim();
        return decimal.Parse(cleaned, CultureInfo.InvariantCulture);
    }
}
