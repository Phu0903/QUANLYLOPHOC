using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    class AddTeacherViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        string _nameteacher;
        public string Name_Teacher { get {
                return _nameteacher;
            }
            set {
                if (value != null)
                {
                    _nameteacher = value;
                    OnPropertyChanged();
                }
            }
            }
        string _address;
        public string Address { get
            {
                return _address;
            }
            set
            {
                if (value != null)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }
        string _PhoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                if (value != null)
                {
                    _PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        string _BirthDay_Teacher;
        public string BirthDay_Teacher
        {
            get
            {
                return _BirthDay_Teacher;
            }
            set
            {
                if (value != null)
                {
                    _BirthDay_Teacher = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Chucvu;
        public string Chucvu
        {
            get
            {
                return _Chucvu;
            }
            set
            {
                if (value != null)
                {
                    _Chucvu = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (value != null)
                {
                    _Email = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (value != null)
                {
                    _Password = value;
                    OnPropertyChanged();
                }
            }
        }

        TeacherInfor _teacherInfor;
        public AddTeacherViewModel(INavigation _navigation, TeacherInfor teacherInfor)
        {
            Navigation = _navigation;
            _teacherInfor = teacherInfor;
            if (_teacherInfor != null)
            {

                Name_Teacher = _teacherInfor.Name_Teacher;
                Address = _teacherInfor.Address;
                PhoneNumber = _teacherInfor.PhoneNumber;
                BirthDay_Teacher = _teacherInfor.BirthDay_Teacher;
                Chucvu = _teacherInfor.Chucvu;
                Email = _teacherInfor.Email;
                Password = _teacherInfor.Password;
                IsVisibleDeleteBtn = true;
            }
        }
        public Command SaveStudent
        {
            get
            {
                return new Command(async () =>
                {
                    if (_teacherInfor != null)
                    {
                        _teacherInfor.Name_Teacher = Name_Teacher;
                        _teacherInfor.Address = Address;
                        _teacherInfor.PhoneNumber = PhoneNumber;
                        _teacherInfor.BirthDay_Teacher = BirthDay_Teacher;
                        _teacherInfor.Chucvu = Chucvu;
                        _teacherInfor.Email = Email;
                        _teacherInfor.Password = Password;
                    }
                    else
                    {
                        _teacherInfor = new TeacherInfor();
                        _teacherInfor.Name_Teacher = Name_Teacher;
                        _teacherInfor.Address = Address;
                        _teacherInfor.PhoneNumber = PhoneNumber;
                        _teacherInfor.BirthDay_Teacher = BirthDay_Teacher;
                        _teacherInfor.Chucvu = Chucvu;
                        _teacherInfor.Email = Email;
                        _teacherInfor.Password = Password;
                    }
                    string url = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/SaveTeacher";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_teacherInfor);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (responseData.Status == 1)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        //
                    }
                });
            }
        }
        bool _isVisibleDeleteBtn;
        public bool IsVisibleDeleteBtn
        {
            get
            {
                return _isVisibleDeleteBtn;
            }
            set
            {
                _isVisibleDeleteBtn = value;
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
