using System.Text.Json.Serialization.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Hosting;
using FocusPilot.Infrastructure.Quotes;
using FocusPilot.Core.Quotes;
using Microsoft.Extensions.Options;

namespace FocusPilot.UI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    public required IQuoteService QuoteService { get; init; }

    [ObservableProperty] 
    private QuoteViewModel _quoteVm;
    
    public MainViewModel(QuoteViewModel quoteVm)
    {
        QuoteVm = quoteVm;
    }
}
