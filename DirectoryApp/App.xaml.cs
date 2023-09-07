using DirectoryApp.Pages;

namespace DirectoryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //sets the default theme to light
            Application.Current.UserAppTheme = AppTheme.Light;

            //sets the main page to the main content page
            MainPage = new NavigationPage(new MainContentPage());

        }


    }




}