using TestApp.ViewModel;

namespace TestApp.View;

public partial class Register : ContentPage
{
    public Register(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Shell.Current.Title = "Register";
    }
}