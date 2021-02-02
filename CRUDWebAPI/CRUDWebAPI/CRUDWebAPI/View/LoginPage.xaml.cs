
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
        public LoginPage(string Chucvu)
        {

            var vm = new LoginviewModel(Navigation, Chucvu);
            this.BindingContext = vm;
            if (vm == null)
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