using CommunityToolkit.Mvvm.Messaging;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.Views;

public partial class FooView
    : UserControl,
        IRecipient<FooViewModel.AlertMessage>,
        IRecipient<FooViewModel.ConfirmAlertRequest>
{
    private readonly BindingSource _bindingSource = new(typeof(FooViewModel), string.Empty);

    protected IMessenger Messenger { get; } = WeakReferenceMessenger.Default;

    public FooView()
    {
        InitializeComponent();

        Load += OnLoad;
        DataContextChanged += OnDataContextChanged;
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        // register all IRecipient<T> implemented messages
        Messenger.RegisterAll(this);

        #region Command bindings

        btnAlert.DataBindings.Add(
            nameof(Button.Command),
            _bindingSource,
            nameof(FooViewModel.AlertCommand),
            true
        );

        #endregion

        #region Data bindings

        txtName.DataBindings.Add(
            nameof(TextBox.Text),
            _bindingSource,
            nameof(FooViewModel.Name),
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        #endregion
    }

    private void OnDataContextChanged(object? sender, EventArgs e)
    {
        _bindingSource.DataSource = DataContext;
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
        DialogResult dialogResult = MessageBox.Show(
            "Confirm alert from " + message.Name,
            "Confirm Alert",
            MessageBoxButtons.YesNo
        );
        message.Reply(
            dialogResult switch
            {
                DialogResult.Yes => true,
                _ => false
            }
        );
    }

    #endregion
}
