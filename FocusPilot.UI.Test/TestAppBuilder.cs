using Avalonia;
using Avalonia.Headless;
using FocusPilot.UI;
using FocusPilot.UI.Test;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace FocusPilot.UI.Test;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}