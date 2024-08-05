# DotnetDataBinding Samples

Super simple sample projects demonstrating the use of CommunityToolkit.Mvvm with common dotnet UI frameworks.

## WinForms

WinForms data binding is written in code-behind rather than using the visual designer, so that it isn't hidden amongst the
rest of the generated UI designer code.

### DevExpress WinForms

> [!NOTE]
> Requires a DevExpress subscription with access to the DevExpress Nuget feed.

> [!WARNING]
> There is currently an issue with binding Commands to DevExpress buttons. See the comments in the `OnLoad` method in [DotnetDataBinding.DXWinForms/Views/FooView.cs](./DotnetDataBinding.DXWinForms/Views/FooView.cs). A workaround is shown in the same file.
