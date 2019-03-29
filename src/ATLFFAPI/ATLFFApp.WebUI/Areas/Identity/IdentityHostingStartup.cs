using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ATLFFApp.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace ATLFFApp.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}