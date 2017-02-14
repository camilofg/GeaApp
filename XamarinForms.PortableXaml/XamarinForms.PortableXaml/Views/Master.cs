using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.PortableXaml.Data;
using XamarinForms.PortableXaml.Models;
using XamarinForms.PortableXaml.ViewModels;
using XamarinForms.PortableXaml.Views;

namespace XamarinForms.PortableXaml
{
    public class Master : ContentPage
    {
        GeaDataBase database;

        private MenuOptionsViewModel ViewModel {
            get { return BindingContext as MenuOptionsViewModel; }
        }
        public Master()
        {
            Title = "MASTER";
            Icon = "slideout.png";
            BackgroundColor = Color.White;
            database = new GeaDataBase();
            //var usToken = database.GetLastToken();
            BindingContext = new MenuOptionsViewModel();

            Xamarin.Forms.Image logo = new Xamarin.Forms.Image
            {
                Source = "icon.png"
            };

            Label header = new Label
            {
                Text = "GEA",
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(22),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var Cabecera = new StackLayout
            {
                Spacing = 4,
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Horizontal,
                Children = { logo, header }
            };

            ScrollView contenedor = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ScrollOrientation.Vertical
            };

            StackLayout sl = new StackLayout();

            Grid DynamicGrid = new Grid();
            RowDefinition[] rows = new RowDefinition[3];
            ColumnDefinition[] columns = new ColumnDefinition[4];

            // Draw Rows.
            for (int i = 0; i < 3; i++)
            {
                rows[i] = new RowDefinition();
                DynamicGrid.RowDefinitions.Add(rows[i]);
                // Setting Row height.
                rows[i].Height = i == 0 ? new GridLength(42) : new GridLength(15);
            }
            // Draw Columns.
            for (int i = 0; i < 4; i++)
            {
                columns[i] = new ColumnDefinition();
                DynamicGrid.ColumnDefinitions.Add(columns[i]);
                if (i % 2 == 0)
                {
                    // Setting column width.
                    columns[i].Width = new GridLength(42);
                }
            }

            var lblImg = new Image { Aspect = Aspect.AspectFit };
            lblImg.Source = ImageSource.FromFile("perfil_cf_42px.jpg");

            Grid.SetRow(lblImg, 0);
            Grid.SetColumn(lblImg, 0);


            var lblImgSearch = new Image { Aspect = Aspect.AspectFit };
            lblImgSearch.Source = ImageSource.FromFile("ic_search_black_24dp.png");

            Grid.SetRow(lblImgSearch, 0);
            Grid.SetColumn(lblImgSearch, 1);

            var lblImgInbox = new Image { Aspect = Aspect.AspectFit };
            lblImgInbox.Source = ImageSource.FromFile("ic_inbox_black_24dp.png");

            Grid.SetRow(lblImgInbox, 0);
            Grid.SetColumn(lblImgInbox, 2);

            var lblUser = new Label();
            lblUser.Text = "Camilo Forero G";

            Grid.SetRow(lblUser, 1);
            Grid.SetColumn(lblUser, 0);
            Grid.SetColumnSpan(lblUser, 4);

            var lblUserMail = new Label();
            lblUserMail.Text = "Camilo@toolsoft.co";

            Grid.SetRow(lblUserMail, 2);
            Grid.SetColumn(lblUserMail, 0);
            Grid.SetColumnSpan(lblUserMail, 4);

            DynamicGrid.Children.Add(lblImg);
            DynamicGrid.Children.Add(lblImgSearch);
            DynamicGrid.Children.Add(lblImgInbox);

            DynamicGrid.Children.Add(lblUser);
            DynamicGrid.Children.Add(lblUserMail); 
            DynamicGrid.BackgroundColor = Color.Aqua;
            sl.Children.Add(DynamicGrid);
            ListView listView = new ListView();
            listView.ItemSelected += ListView_ItemSelected;
            listView.ItemTemplate = new DataTemplate(typeof(CellOptions));
            listView.RowHeight = Device.OnPlatform(28, 28, 36);
            listView.ItemsSource = ViewModel.ListMenu;
            //sl.Children.Add(Cabecera);
            sl.Children.Add(listView);
            Content = sl;
            ScheduleWebRequest();
        }

        private void ScheduleWebRequest()
        {
            Device.StartTimer(TimeSpan.FromSeconds(Convert.ToDouble(App.gpsTimer)), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    var currentLoc = await App.serviceManager.getLocation();
                    var chargeRemaining = App.batteryManagerTest.getRemainingCharge();
                    currentLoc.UserId = App.usuarioSesion.Id;
                    currentLoc.BatteryRemaining = chargeRemaining;
                    database.saveGeneric(currentLoc);
                    ScheduleWebRequest();
                });

                return false;
            });
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavigationPage detalle = null;
            App.MD.IsPresented = false;
            var item = e.SelectedItem as MenuOptions;
            if (item.EPPvalidation)
            {
                var ret = await DisplayActionSheet("Tiene el equipo de protección?", "Cancel", null, "SI", "NO");
                if (ret == "NO" || ret == "Cancel")
                    return;
            }
                switch (item.Name)
            {
                case "About": detalle = new NavigationPage(new AboutPage()); break;
                case "Inicio": detalle = new NavigationPage(new Views.CameraPage()); break;
                case "Configuración": detalle = new NavigationPage(new Views.Configuraciones()); break;
            }
            if (detalle == null) return;
            detalle.BarTextColor = Color.White;
            App.MD.IsPresented = false;
            App.NV = detalle;
            App.MD.Detail = App.NV;
        }
    }
}
