using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MemoryGameForLawyers.Droid;
using Rg.Plugins.Popup;
using Android.Webkit;
using Refractored.XamForms.PullToRefresh.Droid;
using Android.Util;

namespace MemoryGameForLawyers.Droid
{
    [Activity(Label = "Escolha Direito",
      Icon = "@drawable/EscolhaDireito",
      Theme = "@style/MainTheme",
      MainLauncher = false,
      ScreenOrientation = ScreenOrientation.Portrait,
      ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            global::Xamarin.Forms.Forms.SetFlags("Brush_Experimental");
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            PullToRefreshLayoutRenderer.Init();
            Popup.Init(this, savedInstanceState);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected virtual void InitPermissions(Bundle bundle)
        {
            PullToRefreshLayoutRenderer.Init();
            Popup.Init(this, bundle);
        }
    }
}