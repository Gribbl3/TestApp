using CommunityToolkit.Maui.Views;
using DirectoryApp.ViewModel;

namespace DirectoryApp.Pages;

public partial class NewContent1 : Popup
{
    public Student StudentData { get; set; }
    public NewContent1(Student studentData)
    {
        InitializeComponent();
        this.StudentData = studentData;
        BindingContext = StudentData;
    }






}