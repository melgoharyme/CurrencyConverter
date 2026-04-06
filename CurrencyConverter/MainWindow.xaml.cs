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
        new { Text = "Select Currency", Value = 0.0 },
        new { Text = "US Dollar", Value = 54.3860 },
        new { Text = "Egyptian Pound", Value = 1.0 },
        new { Text = "Euro", Value = 62.8213 },
        new { Text = "Pound Sterling", Value = 72.0506 },
        new { Text = "Swiss Franc", Value = 68.1871 },
        new { Text = "Japanese Yen", Value = 34.1021 },
        new { Text = "Saudi Riyal", Value = 14.4856 },
        new { Text = "Kuwaiti Dinar", Value = 177.1531 },
        new { Text = "UAE Dirham", Value = 14.8033 },
        new { Text = "Chinese yuan", Value = 7.9017 }
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

    private void OnConvertClicked(object sender, RoutedEventArgs e)
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

        double sourceRate = Convert.ToDouble(cmbFromCurrency.SelectedValue);
        double targetRate = Convert.ToDouble(cmbToCurrency.SelectedValue);

        double convertedAmount;

        if (sourceRate == targetRate)
            convertedAmount = inputAmount;
        else
            convertedAmount = (inputAmount * sourceRate) / targetRate;

        var sourceCurrencyName = ((dynamic)cmbFromCurrency.SelectedItem).Text;
        var targetCurrencyName = ((dynamic)cmbToCurrency.SelectedItem).Text;

        lblResult.Text = $"{inputAmount} {sourceCurrencyName} = {convertedAmount:N2} {targetCurrencyName} ";
        lblResult.Visibility = Visibility.Visible;
    }

    private void OnClearClicked(object sender, RoutedEventArgs e)
    {
        ResetForm();
    }

}
