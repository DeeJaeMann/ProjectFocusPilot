using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using FocusPilot.UI.ViewModels;
using FocusPilot.UI.Views;
using FocusPilot.Infrastructure.Quotes;
using FocusPilot.Core.Quotes;

namespace FocusPilot.UI.Test;

public class WelcomeTest
{
    public static ServiceProvider AppServices { get; private set; }
    
    /// <summary>
    /// Verifies that FocusPilot.UI.Test is connected to FocusPilot.UI by testing for the default template welcome message
    /// </summary>
    /// <remarks>
    /// This test is just for validation of the test suite.
    /// </remarks>
    /// <example>
    /// Example usage:
    /// <code>
    /// var window = new MainWindow { DataContext = new MainViewModel() };
    /// window.Show();
    /// var textBlock = window.GetVisualDescendants().OfType<TextBlock>().FirstOrDefault();
    /// Assert.Equal("Welcome to Avalonia!", textBlock.Text);
    /// </code>
    /// </example>
    [AvaloniaFact]
    public void FirstTextBlockContainsWelcomeMessage()
    {

        
        // Load embedded config
        var options = LoadZenQuotesOptions();
        
        // Register services manually
        var services = new ServiceCollection();
        services.AddSingleton(options);
        services.AddHttpClient<IQuoteService, ZenQuotesClient>();
        services.AddTransient<QuoteViewModel>();
        services.AddTransient<MainViewModel>();
        
        AppServices = services.BuildServiceProvider();
        
        // Arrange: Create and show the main window
        var window = new MainWindow
        {
            //DataContext = new MainViewModel()
            DataContext = AppServices.GetRequiredService<MainViewModel>()
        };
        
        window.Show();
        
        // Act: Find the TextBox by name or type
        var quoteLabel = window.GetVisualDescendants()
            .OfType<Label>()
            .FirstOrDefault(ql => ql.Name == "QuoteLabel");
        var quoteText = window.GetVisualDescendants()
            .OfType<TextBlock>()
            .FirstOrDefault(ql => ql.Name == "QuoteText");
        var authorLabel = window.GetVisualDescendants()
            .OfType<Label>()
            .FirstOrDefault(ql => ql.Name == "AuthorLabel");
        var authorText = window.GetVisualDescendants()
            .OfType<TextBlock>()
            .FirstOrDefault(ql => ql.Name == "AuthorText");
        
        // Assert: Verify it contains the expected welcome text
        Assert.NotNull(quoteLabel);
        Assert.NotNull(quoteText);
        Assert.NotNull(authorLabel);
        Assert.NotNull(authorText);
        Assert.Equal("Quote:", quoteLabel.Content);
        // When testing for failure, Acutal is null (call is async)
        Assert.NotEqual(String.Empty, quoteText.Text);
        Assert.Equal("Author:", authorLabel.Content);
        // Same as for quoteText.Text (bad test, refactor to use Moq instead of http)
        Assert.NotEqual(String.Empty, authorText.Text);
        
            


    }
    private ZenQuotesClientOptions LoadZenQuotesOptions()
    {
        //var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var uri = new Uri("avares://FocusPilot.UI/appsettings.json");
        
        //using var stream = assets.Open(uri);
        using var stream = AssetLoader.Open(uri);
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();
        
        var configRoot = JsonSerializer.Deserialize<JsonElement>(json);
        var section = configRoot.GetProperty("Quotes").GetProperty("ZenQuotes");
        
        return new ZenQuotesClientOptions
        {
            BaseUrl = section.GetProperty("BaseUrl").GetString() ?? "",
            Timeout = TimeSpan.Parse(section.GetProperty("Timeout").GetString() ?? "00:00:10"),
            ApiKey = section.GetProperty("ApiKey").GetString() ?? ""
        };
    }
}
