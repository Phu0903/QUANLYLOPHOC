using Xamarin.Forms.Internals;


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using CRUDWebAPI.View;
using CRUDWebAPI.View.Teacher;

namespace CRUDWebAPI.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login with social icon page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginWithSocialIconViewModel : INotifyPropertyChanged
    {
     
        public INavigation Navigation { get; set; }


        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string Username;
        public string username
        {
            get { return Username; }
            set
            {
                Username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("username"));
            }
        }
        private string Password;
        public string password
        {
            get { return Password; }
            set
            {
                Password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }
        public Command SubmitCommand { protected set; get; }
        public LoginWithSocialIconViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.SubmitCommand = new Command(async () => await OnSubmit());

        }
        public async Task OnSubmit()
        {
            if (Username != "phu" || Password != "1")
            {
                DisplayInvalidLoginPrompt();
            }

            else
            {

                //await Navigation.PushModalAsync(new TabbedPage1(username,password));

                await Navigation.PushModalAsync(new TabbedPageTeacher(username, password));

            }
        }
    }
}
