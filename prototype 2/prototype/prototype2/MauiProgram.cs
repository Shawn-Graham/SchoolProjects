using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prototype2.Resources.Data;

namespace prototype2
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
            builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer("Server=LAPTOP-91F1SBEI\\SQLEXPRESS;Database=RentalCompnay;User Id=SA;Password=S826agye;Connect Timeout=30;TrustServerCertificate=True;", sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Number of retry attempts
            maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
            errorNumbersToAdd: null // Additional error numbers to retry on
        );
    }));
            
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<CustomerManager>();
            builder.Services.AddScoped<EquipmentManager>();
            builder.Services.AddScoped<RentalManager>();
            builder.Services.AddSingleton<Customer>();
            builder.Services.AddSingleton<Rental>();
            builder.Services.AddSingleton<Equipment>();
     

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        
    }
}
