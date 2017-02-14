using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinForms.PortableXaml;

namespace XamarinForms.PortableXaml
{
    public class ServiceManager
    {
        ILocatorService locatorService;

        public ServiceManager(ILocatorService service)
        {
            locatorService = service;
        }

        public async Task<Position> getLocation() {
            var location = await locatorService.getCurrentLocation();
            return location;
        }
    }

    public class BatteryManagerTest
    {
        IBattery batteryService;

        public BatteryManagerTest(IBattery service) {
            batteryService = service;
        }

        public BatteryStatus getBatteryStatus() {
            return batteryService.Status;
        }

        public int getRemainingCharge()
        {
            return batteryService.RemainingChargePercent;
        }

    }
}
