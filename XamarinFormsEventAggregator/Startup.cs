using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XamarinFormsEventAggregator.Events;
using XamarinFormsEventAggregator.ViewModels;
using XamarinFormsEventAggregator.ViewModels.Interfaces;

namespace XamarinFormsEventAggregator
{
    public static class Startup
    {
        public static App Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {

            var host = new HostBuilder()
                            .ConfigureServices((c, x) =>
                            {
                                nativeConfigureServices(c, x);
                                ConfigureServices(c, x);
                            })
                            .Build();

            App.ServiceProvider = host.Services;

            return App.ServiceProvider.GetService<App>();
        }


        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            if (ctx.HostingEnvironment.IsDevelopment())
            {

            }

            services.AddTransient<IMainViewModel, MainViewModel>();
            services.AddTransient<ISomarViewModel, SomarViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<SomarPage>();
            //Importante ser singleton
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<App>();
          
        }
    }
}
