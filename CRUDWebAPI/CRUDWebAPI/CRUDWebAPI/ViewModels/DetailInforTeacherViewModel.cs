using CRUDWebAPI.View;
using CRUDWebAPI.View.Admin;
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

    class DetailInforTeacherViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public string Name_Teacher { get; set; }
        public string Chucvu { get; set; }
        public string BirthDay_Teacher { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ID_Teacher { get; set; }
        public string Password { get; set; }

        TeacherInfor _teacherInfor;
     public DetailInforTeacherViewModel(INavigation _navigation, TeacherInfor teacherInfor)
        {
            Navigation = _navigation;
            _teacherInfor = teacherInfor;
            if(_teacherInfor != null)
            {
                Name_Teacher = _teacherInfor.Name_Teacher;
                Chucvu = _teacherInfor.Chucvu;
                BirthDay_Teacher = _teacherInfor.BirthDay_Teacher;
                PhoneNumber = _teacherInfor.PhoneNumber;
                Email = _teacherInfor.Email;
                Address = _teacherInfor.Address;
                ID_Teacher = _teacherInfor.ID_Teacher;
                Password = _teacherInfor.Password;
            }    
        }
        /// <summary>
        /// Lấy tất cả các lớp mà giáo viên đó đang dạy
        /// </summary>
        public async void GetClassStudent()
        {
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "http://quanlylophoc.somee.com/api/Masters/GetClassForTeacher?ID_Teacher=" + ID_Teacher.ToString();
                var result = await client.GetStringAsync(uri);
                var StudentList = JsonConvert.DeserializeObject<List<ClassStudent>>(result);
                Class = new ObservableCollection<ClassStudent>(StudentList);
                IsRefreshing = false;
            }
        }
        
        ObservableCollection<ClassStudent> _class;
        public ObservableCollection<ClassStudent> Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
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
        //Hàm edit Teacher
        public Command EditTeacher
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddTeacher(_teacherInfor));
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
