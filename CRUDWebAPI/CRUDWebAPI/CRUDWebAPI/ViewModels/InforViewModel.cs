﻿using CRUDWebAPI.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CRUDWebAPI
{
    class InforViewModel : INotifyPropertyChanged
    {
        private INavigation navigation { get; set; }
        //private string email;
        //private string password;

        public InforViewModel(INavigation _navigation)
        {
            this.navigation = _navigation;
            //this.email = email;
            //this.password = password;
        }
        public async void GetInforTeacher()
        {
            string email = Preferences.Get("my_key", "default_value");
            string password = Preferences.Get("my_key2", "default_value");
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetTeacherLogin?email=" + email.ToString() + "&password=" + password.ToString();
                //var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetTeacherLogin?email=18520129@gm.uit.edu.vn&password=1";
                var result = await client.GetStringAsync(uri);
                var TeacherInfor = JsonConvert.DeserializeObject<List<Teacher>>(result);
                TeacherInfo = new ObservableCollection<Teacher>(TeacherInfor);
                IsRefreshing = false;
            }
        }
        ObservableCollection<Teacher> _teacher;
        public ObservableCollection<Teacher> TeacherInfo
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                OnPropertyChanged();
            }
        }
        bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
