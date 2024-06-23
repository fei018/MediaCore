using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediaCore.Extentions
{
    public static class LifetimeEventsHostedService
    {
        public static void RegisterApplicationLifetimeEvents(this IHost host)
        {
            var hostApplicationLifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
            hostApplicationLifetime.ApplicationStarted.Register(() => OnStarted(host));
            //hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
            //hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
        }

        private static void OnStarted(IHost host)
        {

        }

        private static void OnStopping(IHost host)
        {
        }

        private static void OnStopped()
        {

        }
    }
}
