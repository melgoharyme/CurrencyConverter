using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Models;

internal class ExchangeRateResponse
{
    [JsonPropertyName("result")]
    public string Result { get; set; } = string.Empty;

    [JsonPropertyName("base_code")]
    public string BaseCode { get; set; } = string.Empty;

    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, double> ConversionRates { get; set; } = new();
}
