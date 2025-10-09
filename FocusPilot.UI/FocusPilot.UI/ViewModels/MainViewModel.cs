using System.Text.Json.Serialization.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Hosting;
using FocusPilot.Infrastructure.Quotes;
using FocusPilot.Core.Quotes;

namespace FocusPilot.UI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    private readonly IQuoteService _quoteService;

    //public string QuoteText { get; set; } = string.Empty;
    //public string QuoteAuthor { get; set; } = string.Empty;
    [ObservableProperty]
    private string _quoteText;
    [ObservableProperty]
    private string _quoteAuthor;
    
    public MainViewModel(IQuoteService quoteService)
    {
        _quoteService = quoteService;
        LoadQuoteAsync();
    }

    private async void LoadQuoteAsync()
    {
        var quote = await _quoteService.GetRandomQuoteAsync();
        QuoteText = quote.Text;
        QuoteAuthor = quote.Author;
    }
}
