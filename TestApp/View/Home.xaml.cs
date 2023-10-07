using TestApp.ViewModel;

namespace TestApp.View;

public partial class Home : ContentPage
{
    public Home(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.Title = "Home";
    }
}