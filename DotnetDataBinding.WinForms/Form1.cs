using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Load += OnLoad;
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        fooView1.DataContext = new FooViewModel();
        fooView1.DataContext = new FooViewModel();
    }
}
