using System.Net;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Xamarin.Forms;
using eShopOnContainers.Windows.Services;
using eShopOnContainers.Core.Services.Dependency;
using eShopOnContainers.Core.Models.Browser;
using eShopOnContainers.Windows.Controls;

[assembly:Dependency(typeof(NativeBrowserService))]
namespace eShopOnContainers.Windows.Services
{
    public class NativeBrowserService : INativeBrowserService
    {
        async Task<BrowserResult> INativeBrowserService.LaunchBrowserAsync(string url)
        {
            var browser = new WebAuthenticationBrokerBrowser();
            var redirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().AbsoluteUri;

            //url = url.Replace(WebUtility.UrlEncode(Constants.RedirectUri), WebUtility.UrlEncode(redirectUri));
            //Constants.RedirectIro = redirectUri;

            return await browser.InvokeAsync(url);
        }
    }
}
