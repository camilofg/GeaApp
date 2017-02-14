using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Media;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForms.PortableXaml.Views
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
        }

        private async void TakePic_Clicked(object sender, EventArgs e) {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported) {
                await DisplayAlert("No Camera", "No Camera available", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name= "Test.jpg"
            });

            if (file == null)
                return;

            Images1.Source = ImageSource.FromStream(() => file.GetStream());
        }

        private async void UploadPic_Clicked(object sender, EventArgs e) {

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No Camera", "No Camera available", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            Images1.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}
