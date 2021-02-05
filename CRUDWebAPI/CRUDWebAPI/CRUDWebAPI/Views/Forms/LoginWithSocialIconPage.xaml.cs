using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using CRUDWebAPI.View;
using CRUDWebAPI.View.Teacher;

namespace CRUDWebAPI.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithSocialIconPage : ContentPage
    {
        
        public LoginWithSocialIconPage(string Chucvu)
        {

            var vm = new LoginviewModel(Navigation, Chucvu);
            this.BindingContext = vm;
            if(vm == null)
            {
                vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Thông báo", "Nhập email và password", "OK");
            }    
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Thông báo", "Sai email hoặc password hoặc chức vụ", "OK");
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
}