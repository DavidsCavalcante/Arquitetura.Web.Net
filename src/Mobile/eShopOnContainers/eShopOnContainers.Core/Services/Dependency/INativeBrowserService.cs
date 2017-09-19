using System.Threading.Tasks;
using eShopOnContainers.Core.Models.Browser;

namespace eShopOnContainers.Core.Services.Dependency
{
    public interface INativeBrowserService
    {
        Task<BrowserResult> LaunchBrowserAsync(string url);
    }
}
