using System;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;

namespace eShopOnContainers.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public static Action<string> OpenUrlCallbackHandler { get; set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            SlideOverKit.iOS.SlideOverKit.Init();
            CachedImageRenderer.Init();

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            OpenUrlCallbackHandler(url.AbsoluteString);
            OpenUrlCallbackHandler = null;
            return true;
        }
    }
}
