﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    public class ListClassViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ListClassViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
        }
        public async void GetClassStudent()
        {
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetClass";
                var result = await client.GetStringAsync(uri);
                var StudentList = JsonConvert.DeserializeObject<List<ClassStudent>>(result);
                Student = new ObservableCollection<ClassStudent>(StudentList);
                IsRefreshing = false;
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
        
        
        ObservableCollection<ClassStudent> _student;
        public ObservableCollection<ClassStudent> Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
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
