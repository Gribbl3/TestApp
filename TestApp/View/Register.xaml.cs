using TestApp.ViewModel;

namespace TestApp.View;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
}