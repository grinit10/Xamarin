using Android.Bluetooth;
using Android.Content;
using System;

namespace SampleApp.Droid
{
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;
        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;

            if (action != BluetoothDevice.ActionFound)
            {
                return;
            }

            // Get the device
            var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

            if (device.BondState != Bond.Bonded)
            {
                Console.WriteLine($"Found device with name: {device.Name} and MAC address: {device.Address}");
            }
        }
    }
}