using Microsoft.UI.Xaml;
using System;

namespace CurrencyConverter;

public sealed partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        ResetForm();
        InitializeCurrencies();
    }

    private void ResetForm()
    {
        txtAmount.Text = string.Empty;
        txtAmountError.Visibility = Visibility.Collapsed;

        if (cmbFromCurrency.Items.Count > 0)
            cmbFromCurrency.SelectedIndex = 0;
        cmbFromCurrencyError.Visibility = Visibility.Collapsed;

        if (cmbToCurrency.Items.Count > 0)
            cmbToCurrency.SelectedIndex = 0;
        cmbToCurrencyError.Visibility = Visibility.Collapsed;
        lblResult.Visibility = Visibility.Collapsed;
    }

    private void InitializeCurrencies()
    {
        var dtCurrency = new[]
        {
        new { Text = "Select Currency", Value = "" },
        new { Text = "USD", Value = "USD" },
        new { Text = "EGP", Value = "EGP" },
        new { Text = "EUR", Value = "EUR" },
        new { Text = "GBP", Value = "GBP" },
        new { Text = "SAR", Value = "SAR" },
        new { Text = "AED", Value = "AED" },
        new { Text = "KWD", Value = "KWD" },
        new { Text = "QAR", Value = "QAR" },
        new { Text = "BHD", Value = "BHD" },
        new { Text = "OMR", Value = "OMR" },
        new { Text = "JOD", Value = "JOD" },
        new { Text = "JPY", Value = "JPY" },
        new { Text = "CNY", Value = "CNY" },
        new { Text = "INR", Value = "INR" },
        new { Text = "KRW", Value = "KRW" },
        new { Text = "TRY", Value = "TRY" },
        new { Text = "CAD", Value = "CAD" },
        new { Text = "AUD", Value = "AUD" },
        new { Text = "NZD", Value = "NZD" },
        new { Text = "CHF", Value = "CHF" },
        new { Text = "SEK", Value = "SEK" },
        new { Text = "NOK", Value = "NOK" },
        new { Text = "DKK", Value = "DKK" },
        new { Text = "PLN", Value = "PLN" },
        new { Text = "CZK", Value = "CZK" },
        new { Text = "HUF", Value = "HUF" },
        new { Text = "RON", Value = "RON" },
        new { Text = "BGN", Value = "BGN" },
        new { Text = "RUB", Value = "RUB" },
        new { Text = "UAH", Value = "UAH" },
        new { Text = "BRL", Value = "BRL" },
        new { Text = "MXN", Value = "MXN" },
        new { Text = "ARS", Value = "ARS" },
        new { Text = "CLP", Value = "CLP" },
        new { Text = "COP", Value = "COP" },
        new { Text = "PEN", Value = "PEN" },
        new { Text = "ZAR", Value = "ZAR" },
        new { Text = "NGN", Value = "NGN" },
        new { Text = "KES", Value = "KES" },
        new { Text = "SGD", Value = "SGD" },
        new { Text = "HKD", Value = "HKD" },
        new { Text = "TWD", Value = "TWD" },
        new { Text = "THB", Value = "THB" },
        new { Text = "MYR", Value = "MYR" },
        new { Text = "PHP", Value = "PHP" },
        new { Text = "IDR", Value = "IDR" },
        new { Text = "PKR", Value = "PKR" },
        new { Text = "BDT", Value = "BDT" },
        new { Text = "LKR", Value = "LKR" }
        };

        cmbFromCurrency.ItemsSource = dtCurrency;
        cmbFromCurrency.DisplayMemberPath = "Text";
        cmbFromCurrency.SelectedValuePath = "Value";
        cmbFromCurrency.SelectedIndex = 0;

        cmbToCurrency.ItemsSource = dtCurrency;
        cmbToCurrency.DisplayMemberPath = "Text";
        cmbToCurrency.SelectedValuePath = "Value";
        cmbToCurrency.SelectedIndex = 0;

    }

    private async void OnConvertClicked(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtAmount.Text) || !double.TryParse(txtAmount.Text, out double inputAmount))
        {
            txtAmountError.Visibility = Visibility.Visible;
            return;
        }
        txtAmountError.Visibility = Visibility.Collapsed;

        if (cmbFromCurrency.SelectedIndex == 0)
        {
            cmbFromCurrencyError.Visibility = Visibility.Visible;
            return;
        }
        cmbFromCurrencyError.Visibility = Visibility.Collapsed;

        if (cmbToCurrency.SelectedIndex == 0)
        {
            cmbToCurrencyError.Visibility = Visibility.Visible;
            return;
        }
        cmbToCurrencyError.Visibility = Visibility.Collapsed;

        var fromCurrency = cmbFromCurrency.SelectedValue as string;
        var toCurrency = cmbToCurrency.SelectedValue as string;

        if (string.IsNullOrWhiteSpace(fromCurrency))
        {
            cmbFromCurrencyError.Visibility = Visibility.Visible;
            return;
        }

        if (string.IsNullOrWhiteSpace(toCurrency))
        {
            cmbToCurrencyError.Visibility = Visibility.Visible;
            return;
        }

        var service = new Services.ExchangeRateService();
        var ratesResponse = await service.GetLatestRatesAsync(fromCurrency);

        double rate = ratesResponse.ConversionRates[toCurrency];

        double convertedAmount = inputAmount * rate;

        double targetRate = Convert.ToDouble(rate);

        var sourceCurrencyName = ((dynamic)cmbFromCurrency.SelectedItem).Text;
        var targetCurrencyName = ((dynamic)cmbToCurrency.SelectedItem).Text;


        lblResult.Text = $"{inputAmount} {sourceCurrencyName} = {convertedAmount:N4} {targetCurrencyName} ";
        lblResult.Visibility = Visibility.Visible;
    }

    private void OnClearClicked(object sender, RoutedEventArgs e)
    {
        ResetForm();
    }

}
