using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using CommunityToolkit.Mvvm.Messaging;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.Avalonia.Views;

public partial class FooView
    : UserControl,
        IRecipient<FooViewModel.AlertMessage>,
        IRecipient<FooViewModel.ConfirmAlertRequest>
{
    protected IMessenger Messenger { get; } = WeakReferenceMessenger.Default;

    public FooView()
    {
        InitializeComponent();

        // register all IRecipient<T> implemented messages
        Messenger.RegisterAll(this);
    }

    private void UserControl_Unloaded(object? sender, RoutedEventArgs e)
    {
        // unregister all IRecipient<T> implemented messages
        Messenger.UnregisterAll(this);

        // deactivate viewmodel
        if (ViewModel is not null)
        {
            ViewModel.IsActive = false;
        }
    }

    #region Message receivers

    void IRecipient<FooViewModel.AlertMessage>.Receive(FooViewModel.AlertMessage message)
    {
        var messageBox = new MessageBox(message.Message, "Alert");
        if (this.GetVisualRoot() is Window window)
        {
            messageBox.ShowDialog(window);
        }
    }

    void IRecipient<FooViewModel.ConfirmAlertRequest>.Receive(
        FooViewModel.ConfirmAlertRequest message
    )
    {
        var messageBox = new MessageBox(
            "Confirm alert from " + message.Name,
            "Alert",
            MessageBox.MessageBoxButtons.YesNo
        );
        if (this.GetVisualRoot() is Window window)
        {
            message.Reply(
                messageBox
                    .ShowDialog<MessageBox.MessageBoxResult>(window)
                    .ContinueWith(o =>
                        o.Result switch
                        {
                            MessageBox.MessageBoxResult.Yes => true,
                            _ => false
                        }
                    )
            );
            return;
        }

        message.Reply(false);
    }

    #endregion
}
