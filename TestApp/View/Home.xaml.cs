using TestApp.ViewModel;

namespace TestApp.View;

public partial class Home : ContentPage
{
    public Home(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Shell.Current.Title = "Home";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}