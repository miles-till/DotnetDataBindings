using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.WPF.Views;

/// <summary>
/// Interaction logic for FooView.xaml
/// </summary>
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

    private void UserControl_Unloaded(object sender, RoutedEventArgs e)
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
        MessageBox.Show(message.Message, "Alert");
    }

    void IRecipient<FooViewModel.ConfirmAlertRequest>.Receive(
        FooViewModel.ConfirmAlertRequest message
    )
    {
        MessageBoxResult messageBoxResult = MessageBox.Show(
            "Confirm alert from " + message.Name,
            "Confirm Alert",
            MessageBoxButton.YesNo
        );
        message.Reply(
            messageBoxResult switch
            {
                MessageBoxResult.Yes => true,
                _ => false
            }
        );
    }

    #endregion
}
