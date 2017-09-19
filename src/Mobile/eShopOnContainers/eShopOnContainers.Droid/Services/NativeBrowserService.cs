using System.Threading.Tasks;
using Xamarin.Forms;
using Android.App;
using eShopOnContainers.Droid.Controls;
using eShopOnContainers.Droid.Services;
using eShopOnContainers.Core.Models.Browser;
using eShopOnContainers.Core.Services.Dependency;

[assembly: Dependency(typeof(NativeBrowserService))]
namespace eShopOnContainers.Droid.Services
{
    public class NativeBrowserService : INativeBrowserService
    {
        async Task<BrowserResult> INativeBrowserService.LaunchBrowserAsync(string url)
        {
            var browser = new ChromeCustomTabsWebView((Activity)Forms.Context);
            return await browser.InvokeAsync(url);
        }
    }
}
