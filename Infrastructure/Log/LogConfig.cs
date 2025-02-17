using Serilog;

namespace mapis.Infrastructure
{
    public static class ApplicationLoggingService
    {
        public static void ConfigureLogging(this IHostBuilder host)
        {
            host.UseSerilog((ctx,lc)=>
            {
                lc.WriteTo.Console();
            });
        }
    }
}