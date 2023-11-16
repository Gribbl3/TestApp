using TestApp.ViewModel;

namespace TestApp.View;

public partial class AddContact : ContentPage
{
    public AddContact(AddContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.Title = "Add Contact";
    }
}