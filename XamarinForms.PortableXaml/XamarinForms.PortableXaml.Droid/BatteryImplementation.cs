using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using BatteryStatus = Android.OS.BatteryStatus;
using XamarinForms.PortableXaml;
using XamarinForms.PortableXaml.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryImplementation))]
namespace XamarinForms.PortableXaml.Droid
{
    public class BatteryImplementation : IBattery
    {
        //private BatteryBroadcastReceiver batteryReceiver;
        public BatteryImplementation() { }

        public int RemainingChargePercent
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                            var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);

                            return (int)Math.Floor(level * 100D / scale);
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }

            }
        }

        public XamarinForms.PortableXaml.BatteryStatus Status
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);
                            if (isCharging)
                                return XamarinForms.PortableXaml.BatteryStatus.Charging;

                            switch (status)
                            {
                                case (int)BatteryStatus.Charging:
                                    return XamarinForms.PortableXaml.BatteryStatus.Charging;
                                case (int)BatteryStatus.Discharging:
                                    return XamarinForms.PortableXaml.BatteryStatus.Discharging;
                                case (int)BatteryStatus.Full:
                                    return XamarinForms.PortableXaml.BatteryStatus.Full;
                                case (int)BatteryStatus.NotCharging:
                                    return XamarinForms.PortableXaml.BatteryStatus.NotCharging;
                                default:
                                    return XamarinForms.PortableXaml.BatteryStatus.Unknown;
                            }
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;

                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);

                            if (!isCharging)
                                return XamarinForms.PortableXaml.PowerSource.Battery;
                            else if (usbCharge)
                                return XamarinForms.PortableXaml.PowerSource.Usb;
                            else if (acCharge)
                                return XamarinForms.PortableXaml.PowerSource.Ac;
                            else if (wirelessCharge)
                                return XamarinForms.PortableXaml.PowerSource.Wireless;
                            else
                                return XamarinForms.PortableXaml.PowerSource.Other;
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }
    }
}