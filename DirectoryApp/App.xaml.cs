using DirectoryApp.Pages;

namespace DirectoryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Register();
            Application.Current.UserAppTheme = AppTheme.Light; //sets the default theme to light
        }
    }


}