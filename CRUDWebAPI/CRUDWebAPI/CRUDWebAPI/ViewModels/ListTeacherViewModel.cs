using CRUDWebAPI.View;
using CRUDWebAPI.View.Admin;
using CRUDWebAPI.View.Teacher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    class ListTeacherViewModel : INotifyPropertyChanged
    {
       
        public INavigation Navigation { get; set; }
        public ListTeacherViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            
        }
        public async void GetListTeacher()
        {
            string email = Preferences.Get("my_key", "default_value");
            string password = Preferences.Get("my_key2", "default_value");
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "http://quanlylophoc.somee.com/api/Masters/GetTeacher?email=" + email.ToString() + "&password=" + password.ToString();
                var result = await client.GetStringAsync(uri);
                var TeacherList = JsonConvert.DeserializeObject<List<TeacherInfor>>(result);
                Listteacher = new ObservableCollection<TeacherInfor>(TeacherList);
                IsRefreshing = false;
            }
        }

        /*public async void GetListTeacher()
        {
            
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/getTeacher";
                var result = await client.GetStringAsync(uri);
                var TeacherList = JsonConvert.DeserializeObject<List<TeacherInfor>>(result);
                Listteacher = new ObservableCollection<TeacherInfor>(TeacherList);
                
                IsRefreshing = false;
            }
        }*/
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
        TeacherInfor _selectedStudent;
        public TeacherInfor SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                if (value != null)
                {
                    Navigation.PushAsync(new DetaiinforTeacher(SelectedStudent));
                }
                OnPropertyChanged();
            }
        }
        public Command AddTeacher
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddTeacher(null));
                });
            }
        }
        ObservableCollection<TeacherInfor> _listteacher;
        public ObservableCollection<TeacherInfor> Listteacher
        {
            get
            {
                return _listteacher;
            }
            set
            {
                _listteacher = value;
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
