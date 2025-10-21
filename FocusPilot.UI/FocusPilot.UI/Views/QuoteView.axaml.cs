using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FocusPilot.Infrastructure.Quotes;
using FocusPilot.UI.ViewModels;

namespace FocusPilot.UI.Views;

public partial class QuoteView : UserControl
{
    public QuoteView()
    {
        InitializeComponent();

        // DataContextChanged += (_, _) =>
        // {
        //     Console.WriteLine($"QuoteView DataContext: {DataContext?.GetType().Name ?? "null"}");
        // };
    }
    
}