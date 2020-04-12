using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using Android.Bluetooth;

namespace SampleApp.Droid
{
    [Activity(Label = "SampleApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private MyBroadcastReceiver _myreceiver = new MyBroadcastReceiver();
        private IntentFilter _intentfilter = new IntentFilter();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            RegisterReceiver(_myreceiver, new IntentFilter(BluetoothDevice.ActionFound));
            MyBroadcastReceiver.Adapter.StartDiscovery();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(_myreceiver, new IntentFilter(BluetoothDevice.ActionFound));
        }
        protected override void OnPause()
        {
            base.OnPause();
            UnregisterReceiver(_myreceiver);
        }
    }
}