using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace XamarinForms.PortableXaml.Droid
{
    //[Activity(Label = "XamarinForms.PortableXaml",  Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "GEA", Theme = "@android:style/Theme.Material.Light",
                Icon = "@drawable/icon",
                //MainLauncher = false, 
                ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity//global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            //base.OnCreate(bundle);

            //global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            App.serviceManager = new ServiceManager(new LocatorService());
            App.batteryManagerTest = new BatteryManagerTest(new BatteryImplementation());
            LoadApplication(new App());
        }
    }
}

