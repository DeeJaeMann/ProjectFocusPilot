namespace FocusPilot.Core.Quotes;

/// <summary>
/// Defines the interface for retrieving motivational quotes.
/// Implementations may source quotes from external APIs, local caches, or fallback providers
/// </summary>
public interface IQuoteService
{
    /// <summary>
    /// Retrieves a simple random motivational quote.
    /// </summary>
    /// <returns>A <see cref="QuoteDto"/> containing the quote text and author.</returns>
    Task<QuoteDto> GetRandomQuoteAsync();
}