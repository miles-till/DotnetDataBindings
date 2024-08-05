using DevExpress.XtraEditors;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.DXWinForms;

public partial class Form1 : XtraForm
{
    public Form1()
    {
        InitializeComponent();

        Load += OnLoad;
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        fooView1.DataContext = new FooViewModel();
    }
}
