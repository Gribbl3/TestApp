using TestApp.ViewModel;

namespace TestApp.View;

public partial class AddContact : ContentPage
{
    public AddContact()
    {
        InitializeComponent();
        BindingContext = new AddContactViewModel();
        //set window title
        Shell.Current.Title = "Add Contact";
    }
}