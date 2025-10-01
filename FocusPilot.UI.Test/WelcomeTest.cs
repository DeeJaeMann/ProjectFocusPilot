using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Controls;
using FocusPilot.UI.ViewModels;
using FocusPilot.UI.Views;
using Xunit;

namespace FocusPilot.UI.Test;

public class WelcomeTest
{
    [AvaloniaFact]
    public void FirstTextBlockContainsWelcomeMessage()
    {
        // Arrange: Create and show the main window
        var window = new MainWindow
        {
            DataContext = new MainViewModel()
        };
        
        window.Show();
        
        // Act: Find the TextBox by name or type
        var textBox = window.GetVisualDescendants()
            .OfType<TextBlock>()
            .FirstOrDefault();
        
        // Assert: Verify it contains the expected welcome text
        Assert.NotNull(textBox);
        Assert.Equal("Welcome to Avalonia!", textBox.Text);
    }
}
