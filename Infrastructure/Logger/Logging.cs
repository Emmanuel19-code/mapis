using Serilog;
using Serilog.Formatting.Json;
namespace mapis.Infrastructure
{
    public static class LoggerConfiguration
    {
        public static void ConfigureLogging(this IHostBuilder host)
        {
            host.UseSerilog((ctx,lc)=>{
                lc.WriteTo.Console();
                lc.WriteTo.Seq("");
                lc.WriteTo.File(new JsonFormatter(),"log.txt");
            });
        }
    }
}