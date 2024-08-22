using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DotnetDataBinding.ViewModels;

public partial class FooViewModel : ObservableRecipient
{
    public sealed class AlertMessage(string message)
    {
        public readonly string Message = message;
    }

    public sealed class ConfirmAlertRequest(string name) : AsyncRequestMessage<bool>
    {
        public readonly string Name = name;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AlertCommand))]
    public string _name = string.Empty;

    public bool CanAlert() => Name != string.Empty;

    [RelayCommand(CanExecute = nameof(CanAlert))]
    public async Task AlertAsync()
    {
        bool confirmed = await Messenger.Send(new ConfirmAlertRequest(Name));
        if (confirmed)
        {
            Messenger.Send(new AlertMessage("Confirmed!"));
        }
    }
}
