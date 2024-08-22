using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DotnetDataBinding.Avalonia.Views;

public partial class MessageBox : Window
{
    public enum MessageBoxButtons
    {
        Ok,
        YesNo,
    }

    public enum MessageBoxResult
    {
        None,
        Ok,
        Yes,
        No,
    }

    public MessageBox()
    {
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
    }

    public MessageBox(
        string message,
        string title,
        MessageBoxButtons messageBoxButtons = MessageBoxButtons.Ok
    )
        : this()
    {
        InitializeComponent();

        Title = title;
        Message.Content = message;

        switch (messageBoxButtons)
        {
            case MessageBoxButtons.Ok:
                var okButton = new Button() { Content = "Ok" };
                okButton.Click += OkButton_Click;
                Buttons.Children.Add(okButton);
                break;
            case MessageBoxButtons.YesNo:
                var yesButton = new Button() { Content = "Yes" };
                yesButton.Click += YesButton_Click;
                Buttons.Children.Add(yesButton);

                var noButton = new Button() { Content = "No" };
                noButton.Click += NoButton_Click;
                Buttons.Children.Add(noButton);
                break;
        }
    }

    private void OkButton_Click(object? sender, RoutedEventArgs e)
    {
        Close(MessageBoxResult.Ok);
    }

    private void YesButton_Click(object? sender, RoutedEventArgs e)
    {
        Close(MessageBoxResult.Yes);
    }

    private void NoButton_Click(object? sender, RoutedEventArgs e)
    {
        Close(MessageBoxResult.No);
    }
}
