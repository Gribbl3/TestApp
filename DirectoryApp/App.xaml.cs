using DirectoryApp.Pages;

namespace DirectoryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Register();
        }
    }
}