using TestApp.ViewModel;

namespace TestApp.View;

public partial class Register : ContentPage
{
    public Register(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.Title = "Register";
    }
}