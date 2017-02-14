using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Geolocator;
using System.Threading.Tasks;
using ModelLayer.Entities;

namespace XamarinForms.PortableXaml.Droid
{
    public class LocatorService : ILocatorService
    {
        public async Task<Position> getCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            try
            {
                var position = await locator.GetPositionAsync(10000);
                return new Position { Accuracy = position.Accuracy, Altitude = position.Altitude, Latitude = position.Latitude, Longitude = position.Longitude, TimeStamp = position.Timestamp };
            }
            catch (Exception ex) {
                throw ex;
            }
            //Console.WriteLine("Position Status: {0}", position.Timestamp);
            //await CreateRealFileAsync();
            //ReadFile();
        }
    }
}