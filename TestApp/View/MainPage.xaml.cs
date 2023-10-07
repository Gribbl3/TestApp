using TestApp.ViewModel;

namespace TestApp.View
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.Current.Title = "Window Title";
        }
    }
}