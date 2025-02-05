﻿using Coursework.Service.Interface;
using Coursework.Service;
using Microsoft.Extensions.Logging;

namespace Coursework
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
            builder.Services.AddMauiBlazorWebView();
            // In MauiProgram.cs
            builder.Services.AddScoped<IUserService, UserService>();  // Register UserService implementation
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IDebtService, DebtService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();

        }
    }
}
