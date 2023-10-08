using TestApp.View;

namespace TestApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Register), typeof(Register));
            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(AddContact), typeof(AddContact));
            //mainpage->register-home -addcontact-mainpage
        }

    }
}