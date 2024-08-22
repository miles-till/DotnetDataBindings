using DotnetDataBinding.ViewModels;

namespace DotnetDataBinding.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public FooViewModel FooViewModel { get; set; } = new();
}
