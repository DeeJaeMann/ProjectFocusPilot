using FocusPilot.Core.Quotes;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FocusPilot.Infrastructure.Quotes;

/// <summary>
/// Retrieves motivational quotes from the ZenQuotes API.
/// Implements <see cref="IQuoteService"/> for use in domain and UI layers.
/// </summary>
public class ZenQuotesClient : IQuoteService
{
    private readonly HttpClient _httpClient;
    private readonly ZenQuotesClientOptions _options;

    public ZenQuotesClient(HttpClient httpClient, IOptions<ZenQuotesClientOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    /// <inheritdoc />
    public async Task<QuoteDto> GetRandomQuoteAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_options.BaseUrl}/random");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync(); 
            var quotes = JsonSerializer.Deserialize<ZenQuoteResponse[]>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (quotes is null || quotes.Length == 0) 
                return new QuoteDto { Text = "No quote available.", Author = "System" };

            return new QuoteDto 
            { 
                Text = quotes[0].Quote, 
                Author = quotes[0].Author
            };
        }
        catch (Exception e)
        { 
            Console.WriteLine(e); 
            return new QuoteDto 
            { 
                Text = "Your limitation-it's only your imagination.", 
                Author = "Fallback"
            };
        }
    }

    private class ZenQuoteResponse
    { 
        [JsonPropertyName("q")]
        public string Quote { get; set; } = string.Empty;
        [JsonPropertyName("a")]
        public string Author { get; set; } = string.Empty;
    }
}
