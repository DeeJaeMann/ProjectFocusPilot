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
        // Arrange: Create and show the main window
        var window = new MainWindow
        {
            DataContext = new MainViewModel()
        };
        
        window.Show();
        
        // Act: Find the TextBox by name or type
        var textBlock = window.GetVisualDescendants()
            .OfType<TextBlock>()
            .FirstOrDefault();
        
        // Assert: Verify it contains the expected welcome text
        Assert.NotNull(textBlock);
        Assert.Equal("Welcome to Avalonia!", textBlock.Text);
    }
}
