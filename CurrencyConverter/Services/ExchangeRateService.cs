using CurrencyConverter.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConverter.Services;

internal class ExchangeRateService
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string API_KEY = "YOUR-API-KEY";

    public async Task<ExchangeRateResponse> GetLatestRatesAsync(string baseCurrency)
    {
        var url = $"https://v6.exchangerate-api.com/v6/{API_KEY}/latest/{baseCurrency}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("API Error");

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ExchangeRateResponse>(json);

        if (result == null)
            throw new Exception("Failed to deserialize API response");

        return result;
    }
}
