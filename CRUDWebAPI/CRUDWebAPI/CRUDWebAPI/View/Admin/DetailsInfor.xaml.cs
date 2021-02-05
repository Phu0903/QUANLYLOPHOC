using CRUDWebAPI.Views.Forms;
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

            resultImage.Source = "hecthor.jpg";
            BindingContext = new InforViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as InforViewModel).GetInforTeacher( );
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
            string answer = await DisplayActionSheet("Đổi ảnh đại diện bằng ?", "Hủy", null ,"Camera", "Chọn ảnh");

            if (answer == "Chọn ảnh")
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
            else if (answer == "Camera")
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

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string answer = await DisplayActionSheet("Đổi ảnh đại diện bằng ?", "Hủy", null, "Camera", "Chọn ảnh");

            if (answer == "Chọn ảnh")
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
            else if (answer == "Camera")
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