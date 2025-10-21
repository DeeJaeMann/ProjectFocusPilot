using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Platform;
using Avalonia.Markup.Xaml;
using FocusPilot.UI.ViewModels;
using FocusPilot.UI.Views;
using FocusPilot.Core.Quotes;
using FocusPilot.Infrastructure.Quotes;

namespace FocusPilot.UI;

public partial class App : Application
{
    public static ServiceProvider AppServices { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
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
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                //DataContext = new MainViewModel()
                DataContext = AppServices.GetRequiredService<MainViewModel>()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                //DataContext = new MainViewModel()
                DataContext = AppServices.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
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