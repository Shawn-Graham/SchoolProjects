using Microsoft.Extensions.Logging;
using GymManagmentFinalProject.Resources.Data;

namespace GymManagmentFinalProject
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
                });

            builder.Services.AddSingleton<DatabaseConnection>();
            builder.Services.AddSingleton<EmployeesClass>();
            builder.Services.AddSingleton<ClientsClass>();  // Add this line to register MembersClass
            builder.Services.AddSingleton<EquipmentClass>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

