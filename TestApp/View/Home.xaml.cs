using TestApp.ViewModel;

namespace TestApp.View;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}