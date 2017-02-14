using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForms.PortableXaml.Data;

namespace XamarinForms.PortableXaml
{
    public partial class Login : ContentPage
    {
        GeaDataBase database;
        public Login()
        {
            InitializeComponent();
            enterButton.Clicked += EnterButton_Clicked;
            IconLogo.Source = "icons_48_android.png";
        }

        private async void EnterButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(userEntry.Text))
            {

                await DisplayAlert("Error", "Debe Ingresar un usuario", "Aceptar");
                userEntry.Focus();
                return;
                /*userEntry.Text = "acorredor";*/
            }

            if (string.IsNullOrEmpty(passwordEntry.Text))
            {

                await DisplayAlert("Error", "Debe Ingresar la clave", "Aceptar");
                passwordEntry.Focus();
                return;
                /*passwordEntry.Text = "1234";*/
            }

            try
            {
                waitActivityIndicator.IsRunning = true;
                database = new GeaDataBase();

                var usuValido = database.validateUser(userEntry.Text, passwordEntry.Text);

                if (usuValido == null)
                {
                    await DisplayAlert("Error", "Usuario o Clave Invalido", "Aceptar");
                    userEntry.Text = "";
                    passwordEntry.Text = "";
                    userEntry.Focus();
                    waitActivityIndicator.IsRunning = false;
                    return;
                }
                database.deletePositions();
                App.usuarioSesion = usuValido;
                var currentLoc = await App.serviceManager.getLocation();

                currentLoc.UserId = App.usuarioSesion.Id;
                database.saveGeneric(currentLoc);

                waitActivityIndicator.IsRunning = false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            App.MD = new MasterDetailPage();
            App.MD.Title = "TITOLO";
            App.MD.Master = new Master();
            App.NV = new NavigationPage(new Detail());
            App.MD.Detail = App.NV;
            App.MD.MasterBehavior = MasterBehavior.SplitOnLandscape;
            Application.Current.MainPage = App.MD;

        }
        
    }
}
