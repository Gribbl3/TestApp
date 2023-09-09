using CommunityToolkit.Maui.Views;
using DirectoryApp.ViewModel;

namespace DirectoryApp.Pages;

public partial class RegisterPopup : Popup
{
    public Student StudentData { get; set; }
    public RegisterPopup(Student studentData)
    {
        InitializeComponent();
        this.StudentData = studentData;
        BindingContext = StudentData;
    }

    private async void OnCloseButtonClicked(object sender, EventArgs e) => await CloseAsync(true);

}