namespace FocusPilot.Core.Quotes;

/// <summary>
/// Represents a motivational quote with its author.
/// </summary>
public class QuoteDto
{
    public string Text { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}