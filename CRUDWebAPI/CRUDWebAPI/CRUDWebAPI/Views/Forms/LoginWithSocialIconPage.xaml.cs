using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using CRUDWebAPI.View;

namespace CRUDWebAPI.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithSocialIconPage : ContentPage
    { 
        public LoginWithSocialIconPage()
        {
            var vm = new LoginviewModel(Navigation);
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();

            username.Completed += (object sender, EventArgs e) =>
            {
                password.Focus();
            };

            password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            if (username.Text != "phu" || password.Text != "1")
            {
                DisplayAlert("Thông báo", "Sai username hoặc password", "OK");
            }
            else
            {
                Navigation.PushAsync(new TabbedPage1());
            }
        }
    }
}