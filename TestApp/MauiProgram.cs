using Microsoft.Extensions.Logging;
using TestApp.Service;
using TestApp.View;
using TestApp.ViewModel;

namespace TestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //services
            builder.Services.AddSingleton<IStudentService, StudentService>();
            builder.Services.AddSingleton<IContactService, ContactService>();

            //viewmodels
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<AddContactViewModel>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();

            //views
            builder.Services.AddTransient<AddContact>();
            builder.Services.AddTransient<Home>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Register>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}