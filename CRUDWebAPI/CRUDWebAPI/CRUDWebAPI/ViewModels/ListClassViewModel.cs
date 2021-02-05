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
    public class ListClassViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public int temp;
        public ListClassViewModel(INavigation _navigation,int page)
        {
            temp = page;
            Navigation = _navigation;
        }
        
        public async void GetClassStudent()
        {
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/getClass";
                var result = await client.GetStringAsync(uri);
                var StudentList = JsonConvert.DeserializeObject<List<ClassStudent>>(result);
                Student = new ObservableCollection<ClassStudent>(StudentList);
                IsRefreshing = false;
            }
        }
        public async void GetClassStudent2()
        {
            string email = Preferences.Get("my_key", "default_value");
            string password = Preferences.Get("my_key2", "default_value");
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetClassForPage?username=" + email.ToString()+ "&password="+password.ToString();
                var result = await client.GetStringAsync(uri);
                var StudentList = JsonConvert.DeserializeObject<List<ClassStudent>>(result);
                Student2 = new ObservableCollection<ClassStudent>(StudentList);
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
        ClassStudent _selectedStudent;
        public ClassStudent SelectedStudent
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
                    if(temp == 2)
                    {
                        Navigation.PushAsync(new ListStudent(SelectedStudent));
                    }    
                    else if(temp ==1 )
                    {
                        Navigation.PushAsync(new MainPage(SelectedStudent));
                    }
                    
                }
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
        ObservableCollection<ClassStudent> _student2;
        public ObservableCollection<ClassStudent> Student2
        {
            get
            {
                return _student2;
            }
            set
            {
                _student2 = value;
                OnPropertyChanged();
            }
        }
        public Command AddClass
        {
            get
            {
              
                return new Command(() =>
                {
                    Navigation.PushAsync(new Addeditclass(null));
                });
            }
        }
      



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
