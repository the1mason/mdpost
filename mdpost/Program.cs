using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace mdpost;

public class Program
{
    public static Models.ConfigModel config { get; set; }
    public static void Main(string[] args)
    {
        config = Utils.ConfigUtils.ReadConfig();
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls(config.AppUrls);
            });
}
