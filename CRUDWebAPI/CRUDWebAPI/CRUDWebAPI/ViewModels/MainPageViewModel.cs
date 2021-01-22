
using Newtonsoft.Json;
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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        ClassStudent _classStudent;
        public MainPageViewModel(INavigation _navigation, ClassStudent classStudent)
        {
            Navigation = _navigation;
            _classStudent = classStudent;


        }
        
        public async void GetStudents()
        {
            var temp = _classStudent.ID_CLass;
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "http://quanlylophoc.somee.com/api/Masters/getStudent?ID_Class=" + temp.ToString();
                var result = await client.GetStringAsync(uri);
                var StudentList = JsonConvert.DeserializeObject<List<Student>>(result);
                Student = new ObservableCollection<Student>(StudentList);
                IsRefreshing = false;
            }
        }
      
        public Command AddStudent
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddStudent(null));
                });
            }
        }
        public Command EditStudent
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddStudent(null));
                });
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
        Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                if(value!=null)
                {
                    Navigation.PushAsync(new AddStudent(SelectedStudent));
                }
                OnPropertyChanged();
            }
        }

        ObservableCollection<Student> _student;
        public ObservableCollection<Student> Student
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
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
