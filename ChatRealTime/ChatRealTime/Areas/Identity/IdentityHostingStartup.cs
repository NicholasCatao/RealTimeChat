[assembly: HostingStartup(typeof(ChatRealTime.Areas.Identity.IdentityHostingStartup))]
namespace ChatRealTime.Areas.Identity
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