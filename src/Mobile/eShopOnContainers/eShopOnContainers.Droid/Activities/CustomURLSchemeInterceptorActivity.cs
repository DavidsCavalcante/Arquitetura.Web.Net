using Android.App;
using Android.Content;
using Android.OS;

namespace eShopOnContainers.Droid.Activities
{
    [Activity(Label = "CustomURLSchemeInterceptorActivity")]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = "io.identitymodel.native",
        DataHost = "callback")]
    public class CustomURLSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MainApplication.CustomUrlSchemeCallbackHandler(Intent.DataString);
            MainApplication.CustomUrlSchemeCallbackHandler = null;

            Finish();
        }
    }
}
