using CRUDWebAPI.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherOrAdmin : ContentPage
    {
        public TeacherOrAdmin()
        {
            InitializeComponent();
        }

        

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new LoginWithSocialIconPage("Giaovien"));
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new LoginWithSocialIconPage("Quanly"));
        }
        /*private void Button_Clicked(object sender, EventArgs e)
        {
            Chucvu = "Quanly";
            Navigation.PushAsync(new LoginAdmin());
        }*/
    }
}