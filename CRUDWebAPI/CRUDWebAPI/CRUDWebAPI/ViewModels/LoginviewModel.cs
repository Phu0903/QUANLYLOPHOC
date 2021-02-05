﻿using Newtonsoft.Json;
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

namespace CRUDWebAPI
{
    public class LoginviewModel : INotifyPropertyChanged
    {
        public class RestClient<T>
        {


            public async Task<bool> checkLogin(string username, string password, string Chucvu)
            {
                string url = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/UserDetailsLogin/Login?email=" + username.ToString() + "&password=" + password.ToString() + "&chucvu="+Chucvu.ToString();

                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(url);

                return response.IsSuccessStatusCode;
            }
        }
        public class LoginService
        {
            // fetch the RestClient<T>
            RestClient<ListTeacher> _restClient = new RestClient<ListTeacher>();

            // Boolean function with the following parameters of username & password.
            public async Task<bool> CheckLoginIfExists(string username, string password, string Chucvu)
            {
                var check = await _restClient.checkLogin(username, password, Chucvu);

                return check;
            }
        }
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
        public LoginviewModel(INavigation navigation,string Chucvu)
        {
            
            this.Navigation = navigation;
            this.SubmitCommand = new Command(async () => await OnSubmit(Chucvu));
            
        }
        public async Task OnSubmit(string Chucvu)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(Username, Password, Chucvu);

            if (getLoginDetails)
            {
               
               if(Chucvu == "Giáo Viên")
                {

                    await Navigation.PushModalAsync(new TabbedPageTeacher(Username, Password));
                }   
                else if (Chucvu == "Quản Lý")
                {
                    await Navigation.PushModalAsync(new TabbedPage1(Username,Password));
                }

                //await Navigation.PushModalAsync(new TabbedPage1());
                //await Navigation.PushModalAsync(new Infor(Username,Password));
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
        }
        
    }
}