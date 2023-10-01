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

            //viewmodels
            builder.Services.AddTransient<RegisterViewModel>();

            //views
            builder.Services.AddTransient<Register>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}