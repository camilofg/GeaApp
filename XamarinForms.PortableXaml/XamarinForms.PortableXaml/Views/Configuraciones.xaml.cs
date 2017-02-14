using System.Linq;

using Xamarin.Forms;
using XamarinForms.PortableXaml.Data;

namespace XamarinForms.PortableXaml.Views
{
    public partial class Configuraciones : ContentPage
    {
        GeaDataBase database;
        public Configuraciones()
        {
            InitializeComponent();
            database = new GeaDataBase();
            var configuraciones = database.getConfigs();
            var urlServ = configuraciones.Where(x => x.ConfigName == "urlServicio").Select(x => x.ConfigValue);
            var gpsTimer = configuraciones.Where(x => x.ConfigName == "gpsTimer").Select(x => x.ConfigValue);

            ServicioUrlTxt.Text = urlServ.Count() == 0 ? App.baseUrl : urlServ.First().ToString();
            GpsTimerTxt.Text = gpsTimer.Count() == 0 ? App.gpsTimer.ToString() : gpsTimer.First().ToString();
            BtnGuardar.Clicked += BtnGuardar_Clicked;
            BtnPosition.Clicked += BtnPosition_Clicked;
        }

        private void BtnPosition_Clicked(object sender, System.EventArgs e)
        {
            var talito = database.getPositions();
            string salida = string.Empty;
            foreach (var item in talito)
            {
                salida += item.Latitude.ToString() + "\n";
            }
            LblPosition.Text = salida;
        }

        private void BtnGuardar_Clicked(object sender, System.EventArgs e)
        {
            if(GpsTimerTxt.Text != App.gpsTimer.ToString())
            {
                if(database.saveGeneric(new XamarinForms.PortableXaml.Models.Configuraciones { ConfigName = "gpsTimer", ConfigValue = GpsTimerTxt.Text }))
                {
                    App.gpsTimer = GpsTimerTxt.Text;
                    DisplayAlert("Configuracion Guardada", string.Format("{0} {1}", "Se guardo la configuracion", "gpsTimer"), "Accept");
                }

            }
            if (database.saveGeneric(new XamarinForms.PortableXaml.Models.Configuraciones { ConfigName = "urlServicio", ConfigValue = ServicioUrlTxt.Text }))
            {
                App.baseUrl = ServicioUrlTxt.Text;
                DisplayAlert("Configuracion Guardada", string.Format("{0} {1}", "Se guardaron la configuracion", "urlServicio"), "Accept");
            }
        }

       
    }
}
