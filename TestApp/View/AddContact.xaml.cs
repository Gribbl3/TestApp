using TestApp.ViewModel;

namespace TestApp.View;

public partial class AddContact : ContentPage
{
    public AddContact(AddContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Shell.Current.Title = "Add Contact";
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

    }
}