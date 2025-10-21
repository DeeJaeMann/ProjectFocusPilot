using System;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using FocusPilot.Infrastructure.Quotes;
using FocusPilot.Core.Quotes;

namespace FocusPilot.UI.ViewModels;

public partial class QuoteViewModel : ViewModelBase
{

    [ObservableProperty]
    private string? _quoteText;
    [ObservableProperty]
    private string? _quoteAuthor;
    
    public required IQuoteService QuoteService { get; init; }
    public IAsyncRelayCommand LoadQuoteCommand { get; }
    
    public QuoteViewModel(IQuoteService quoteService)
    {
        QuoteService = quoteService;
        LoadQuoteCommand = new AsyncRelayCommand(LoadQuoteAsync);
        // Quick fix to load first query
        // Will investigate a better implementation
        _ = LoadQuoteAsync();
    }

    private async Task LoadQuoteAsync()
    {
        var quote = await QuoteService.GetRandomQuoteAsync();
        QuoteText = quote.Text;
        QuoteAuthor = quote.Author;
        //Console.WriteLine($"QuoteText: {quote.Text}");
        //Console.WriteLine($"QuoteAuthor: {quote.Author}");
        // Added delay to prevent sending too many requests per second to API
        // Add exception handling if task is closed early
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}