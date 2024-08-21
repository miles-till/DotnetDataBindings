using CommunityToolkit.Mvvm.Messaging;
using DevExpress.XtraEditors;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.DXWinForms.Views;

public partial class FooView
    : XtraUserControl,
        IRecipient<FooViewModel.AlertMessage>,
        IRecipient<FooViewModel.ConfirmAlertRequest>
{
    private readonly BindingSource _bindingSource = new(typeof(FooViewModel), string.Empty);

    protected IMessenger Messenger { get; } = WeakReferenceMessenger.Default;

    protected FooViewModel? ViewModel => _bindingSource.Current as FooViewModel;

    public FooView()
    {
        InitializeComponent();

        // register all IRecipient<T> implemented messages
        Messenger.RegisterAll(this);

        Disposed += OnDisposed;
        Load += OnLoad;
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDisposed(object? sender, EventArgs e)
    {
        // unregister all IRecipient<T> implemented messages
        Messenger.UnregisterAll(this);
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        #region Command bindings

        // binding like this causes NonSupportedException in DevExpress.Utils.v24.1.dll
        // but works for base WinForms controls (see DotnetDataBinding.WinForms.FooView)
        // workaround - command binding is done in OnDataContextChanged

        //btnAlert.DataBindings.Add(
        //    nameof(SimpleButton.Command),
        //    _bindingSource,
        //    nameof(FooViewModel.AlertCommand),
        //    true
        //);

        #endregion

        #region Data bindings

        txtName.DataBindings.Add(
            nameof(TextEdit.EditValue),
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

        // bind commands (workaround due to NonSupportedException in DevExpress.Utils)
        btnAlert.Command = ViewModel?.AlertCommand;
    }

    #region Message receivers

    void IRecipient<FooViewModel.AlertMessage>.Receive(FooViewModel.AlertMessage message)
    {
        XtraMessageBox.Show(message.Message, "Alert");
    }

    void IRecipient<FooViewModel.ConfirmAlertRequest>.Receive(
        FooViewModel.ConfirmAlertRequest message
    )
    {
        DialogResult dialogResult = XtraMessageBox.Show(
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
