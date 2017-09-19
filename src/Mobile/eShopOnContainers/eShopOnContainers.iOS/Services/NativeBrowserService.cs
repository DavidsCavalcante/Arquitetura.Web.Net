using Xamarin.Forms;
using eShopOnContainers.iOS.Services;
using eShopOnContainers.Core.Models.Browser;
using eShopOnContainers.Core.Services.Dependency;
using UIKit;
using Foundation;
using SafariServices;
using System.Threading.Tasks;

[assembly: Dependency(typeof(NativeBrowserService))]
namespace eShopOnContainers.iOS.Services
{
    public class NativeBrowserService : INativeBrowserService
    {
        UIViewController rootViewController;
        SFSafariViewController safari;

        Task<BrowserResult> INativeBrowserService.LaunchBrowserAsync(string url)
        {
            var tcs = new TaskCompletionSource<BrowserResult>();

            AppDelegate.OpenUrlCallbackHandler = async (response) =>
            {
                await safari.DismissViewControllerAsync(true);

                tcs.SetResult(new BrowserResult
                {
                    Response = response,
                    ResultType = BrowserResultType.Success
                });
            };

            rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            safari = new SFSafariViewController(new NSUrl(url));
            rootViewController.PresentViewController(safari, true, null);

            return tcs.Task;
        }
    }
}
