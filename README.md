## Currency Converter WinUI 3 & ExchangeRate API

A simple, uptime and reliable currency converter desktop app built using WinUI 3 that integrates live currency rates via ExchangeRate API.
It allows converting amounts between multiple currencies with a clean, minimal interface.

### Features

- Convert between multiple uptime currencies (USD, EUR, GBP, JPY, etc.)
- Input validation for amount
- Error messages for invalid inputs
- Reset/Clear all fields
- Simple and responsive UI

### Screenshot

![Static Currency Converter using WinUI3](Screenshot.png)

### Usage

- Enter the amount in the Amount textbox.
- Select From currency and To currency.
- Click Convert to see the converted result.
- Click Clear to reset all fields.

## Technologies Used

- C#
- WinUI 3 (.NET 10)
- XAML for UI
- ExchangeRate API

## **Notes**

- Replace `YOUR-API-KEY` to your ExchangeRate API. 
- API Docs: [ExchangeRate API Documentation](https://www.exchangerate-api.com/docs/standard-requests)
- List of currency codes and countries supported: [Supported Currencies](https://www.exchangerate-api.com/docs/supported-currencies)