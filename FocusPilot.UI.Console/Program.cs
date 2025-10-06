using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FocusPilot.Core.Quotes;
using FocusPilot.Infrastructure.Quotes;

namespace FocusPilot.UI.Console;
class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Bind ZenQuotesClientOptions from config
                services.Configure<ZenQuotesClientOptions>(
                    context.Configuration.GetSection("Quotes:ZenQuotes"));

                // Register the quote service with HttpClient
                services.AddHttpClient<IQuoteService, ZenQuotesClient>();
            })
            .Build();
        
        // Resolve and use the quote service
        var quoteService = host.Services.GetRequiredService<IQuoteService>();
        var quote = await quoteService.GetRandomQuoteAsync();
        
        WriteLine($"\"{quote.Text}\"");
        WriteLine($"   - {quote.Author}");
    }
}