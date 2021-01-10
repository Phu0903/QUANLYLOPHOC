
using CRUDWebAPI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
    }

        /*private void Button_Clicked(object sender, EventArgs e)
        {
            /*if ((username.Text == "18520129" && password.Text == "1") || (username.Text == "18520890" && password.Text == "1"))
            {
                Navigation.PushAsync(new MainPage());
            }*/

           /* User user = new User(username.Text, password.Text);
            if (user.CheckInformation())
            {
                //DisplayAlert("Login", "Login Success", "OK");
                Navigation.PushAsync(new TabbedPage1());
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, error username or password", "OK");
            }
        }*/
    
}