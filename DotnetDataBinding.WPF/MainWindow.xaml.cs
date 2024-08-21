using System.Windows;
using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        FooView.DataContext = new FooViewModel();
    }
}
