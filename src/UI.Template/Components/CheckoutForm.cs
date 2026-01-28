using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components;

public class CheckoutForm(By locator) : BaseComponent(locator)
{
    private TextInput FirstName => new(By.XPath($"{Locator.ToSelector()}//*[@id='firstName']"));
    private TextInput LastName => new(By.XPath($"{Locator.ToSelector()}//*[@id='lastName']"));
    private TextInput Street => new(By.XPath($"{Locator.ToSelector()}//*[@id='street']"));
    private TextInput City => new(By.XPath($"{Locator.ToSelector()}//*[@id='city']"));
    private TextInput ZipCode => new(By.XPath($"{Locator.ToSelector()}//*[@id='zipCode']"));
    private TextInput Email => new(By.XPath($"{Locator.ToSelector()}//*[@id='email']"));
    private TextInput PhoneNumber => new(By.XPath($"{Locator.ToSelector()}//*[@id='phoneNumber']"));
    private DropDownList PaymentMethod => new(By.XPath($"{Locator.ToSelector()}//*[@id='paymentMethod']"));
    private Button PayButton => new(By.XPath($"{Locator.ToSelector()}//*[@class='pay-button']"));

    /// <summary>
    /// Sets the value to text input.
    /// </summary>
    /// <param name="textInput">The text input.</param>
    /// <param name="value">The value to set.</param>
    /// <returns>True if the value was set correctly, false otherwise.</returns>
    private static bool SetText(TextInput textInput, string value)
    {
        textInput.Clear();
        textInput.SendKeys(value);
        return textInput.GetValue().Equals(value, StringComparison.Ordinal);
    }

    /// <summary>
    /// Sets the first name.
    /// </summary>
    /// <param name="firstName">The first name to set.</param>
    /// <returns>True if the name was set correctly, false otherwise.</returns>
    public bool SetFirstName(string firstName)
    {
        return SetText(FirstName, firstName);
    }

    /// <summary>
    /// Sets the last name.
    /// </summary>
    /// <param name="lastName">The first name to set.</param>
    /// <returns>True if the name was set correctly, false otherwise.</returns>
    public bool SetLastName(string lastName)
    {
        return SetText(LastName, lastName);
    }

    /// <summary>
    /// Sets the street.
    /// </summary>
    /// <param name="street">The street to set.</param>
    /// <returns>True if the street was set correctly, false otherwise.</returns>
    public bool SetStreet(string street)
    {
        return SetText(Street, street);
    }

    /// <summary>
    /// Sets the city.
    /// </summary>
    /// <param name="city">The city to set.</param>
    /// <returns>True if the city was set correctly, false otherwise.</returns>
    public bool SetCity(string city)
    {
        return SetText(City, city);
    }

    /// <summary>
    /// Sets the ZIP Code.
    /// </summary>
    /// <param name="zipCode">The ZIP Code to set.</param>
    /// <returns>True if the ZIP Code was set correctly, false otherwise.</returns>
    public bool SetZipCode(string zipCode)
    {
        return SetText(ZipCode, zipCode);
    }

    /// <summary>
    /// Sets the email.
    /// </summary>
    /// <param name="email">The email to set.</param>
    /// <returns>True if the email was set correctly, false otherwise.</returns>
    public bool SetEmail(string email)
    {
        return SetText(Email, email);
    }

    /// <summary>
    /// Sets the phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number to set.</param>
    /// <returns>True if the phone number was set correctly, false otherwise.</returns>
    public bool SetPhoneNumber(string phoneNumber)
    {
        return SetText(PhoneNumber, phoneNumber);
    }

    /// <summary>
    /// Selects the payment method.
    /// </summary>
    /// <param name="paymentMethod">The payment method number to set.</param>
    /// <returns>True if the payment method was set correctly, false otherwise.</returns>
    public bool SelectPaymentMethod(string paymentMethod)
    {
        PaymentMethod.SelectByText(paymentMethod);
        return PaymentMethod.GetSelectedOptionText() == paymentMethod;
    }

    /// <summary>
    /// Click the Pay button.
    /// </summary>
    public void ClickPay()
    {
        PayButton.Click();
    }
}
