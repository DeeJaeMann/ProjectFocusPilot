using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FocusPilot.Core.Quotes;
using FocusPilot.Infrastructure.Quotes;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Xunit;

namespace FocusPilot.Infrastructure.Quotes.Test;

public class ZenQuotesClientTest
{
    /// <summary>
    /// Verifies that <see cref="ZenQuotesClient"/> correctly deserializes a successful API response
    /// into a <see cref="QuoteDto"/> object with expected text and author values.
    /// </summary>
    /// <remarks>
    /// This test mocks <see cref="HttpClient"/> to simulate a valid JSON payload from ZenQuotes.
    /// It ensures that the client honors the contract defined by <see cref="IQuoteService"/> and
    /// returns a non-null, populated <see cref="QuoteDto"/> when the API responds successfully.
    /// </remarks>
    [Fact]
    public async Task GetRandomQuoteAsync_ReturnsQuoteDto_WhenApiSucceeds()
    {
        // Arrange
        var json = "[{\"q\":\"Test quote\",\"a\":\"Test author\"}]";
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json),
            });
        var httpClient = new HttpClient(handlerMock.Object);
        var options = Options.Create(new ZenQuotesClientOptions { BaseUrl = "https://zenquotes.io/api" });
        var client = new ZenQuotesClient(httpClient, options);
        
        // Act
        var result = await client.GetRandomQuoteAsync();
        
        // Assert
        Assert.Equal("Test quote", result.Text);
        Assert.Equal("Test author", result.Author);
    }
}
