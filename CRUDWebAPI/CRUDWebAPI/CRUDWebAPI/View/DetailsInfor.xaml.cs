using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsInfor : ContentPage
    {
        public DetailsInfor()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnnouncePage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Thông báo", "Đổi ảnh đại diện bằng ?", "Camera", "Chọn ảnh");

            if (answer == false)
            {

                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    resultImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            else
            {
                var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    resultImage.Source = ImageSource.FromStream(() => stream);
                }
            }
        }
    }
}