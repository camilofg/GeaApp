using ModelLayer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using XamarinForms.PortableXaml;
using XamarinForms.PortableXaml.Data;
using XamarinForms.PortableXaml.Models;

namespace XamarinForms.PortableXaml
{
    public partial class App : Application
    {
        
        public static MasterDetailPage MD { get; set; }
        public static NavigationPage NV { get; set; }
        //public static string urlBase = "http://192.168.0.3/WSServimeterSGS/api/";
        public static string baseUrl { get; set; }

        GeaDataBase database;
        public static Usuario usuarioSesion { get; set; }

        public static ServiceManager serviceManager;

        public static BatteryManagerTest batteryManagerTest;
        public static string gpsTimer { get; set; }

        public App()
        {
            InitializeComponent();
            baseUrl = "http://35.162.0.224/WSServimeterSGS/api/";
            gpsTimer = "1";
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            database = new GeaDataBase();

            var configuraciones = database.getConfigs();
            var newUrlService = configuraciones.Where(x => x.ConfigName == "urlServicio").Select(x => x.ConfigValue);
            var newGpsTimer = configuraciones.Where(x => x.ConfigName == "gpsTimer").Select(x => x.ConfigValue);

            gpsTimer = newGpsTimer.Count() > 0 ? newGpsTimer.First() : gpsTimer;

            if (database.countUsers() == 0)
            {
                HttpClient cliente = new HttpClient();
                if (newUrlService.Count() > 0)
                    baseUrl = String.Format("{0}/api/", newUrlService);

                cliente.BaseAddress = new Uri(baseUrl);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var salida = cliente.GetStringAsync("User").Result;
                var ListaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(salida);

                database.saveUsers(ListaUsuarios);

            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
