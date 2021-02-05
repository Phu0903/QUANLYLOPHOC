using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI
{
    class AddStudentViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        Student _student;
        public AddStudentViewModel(INavigation _navigation, Student student)
        {
            Navigation = _navigation;
            _student = student;
            if (_student != null)
            {

                Name = _student.Name;
                Phone = _student.PhoneNumber;
                Address = _student.Address;
                Birthday = _student.Birthday;
                NameClass = _student.ID_Class;
                RegisterDay = _student.RegisterDay;
                Gender = _student.Gender;
                StudentTittle = "Sửa thông tin sinh viên";
                IsVisibleDeleteBtn = true;
            }
            else
            {
                StudentTittle = "Thêm sinh viên";
            }
        }

        public Command SaveStudent
        {
            get
            {
                return new Command(async () =>
                {
                    if (_student != null)
                    {
                        _student.Name = Name;
                        _student.Address = Address;
                        _student.PhoneNumber = Phone;
                        _student.Birthday = Birthday;
                        _student.ID_Class = NameClass;
                        _student.RegisterDay = RegisterDay;
                        _student.Gender = Gender;
                    }
                    else
                    {
                        _student = new Student();
                        _student.Name = Name;
                        _student.Address = Address;
                        _student.PhoneNumber = Phone;
                        _student.Birthday = Birthday;
                        _student.ID_Class = NameClass;
                        _student.RegisterDay = RegisterDay;
                        _student.Gender = Gender;

                    }
                    string url = " https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/SaveStudent";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_student);
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
        public Command DeleteStudent
        {
            get
            {
                return new Command(async () =>
                {
                    string url = $"https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/DeleteStudent?StudentId={_student.ID_Student}";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_student);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    string result = await response.Content.ReadAsStringAsync();
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (responseData.Status == 1)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Message", responseData.Message, "ok");
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

        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        string _address;
        public string Address
        {
            get
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

        string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != null)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }
        string _birth;
        public string Birthday
        {
            get
            {
                return _birth;
            }
            set
            {
                if (value != null)
                {
                    _birth = value;
                    OnPropertyChanged();
                }
            }
        }
        string _NameClass;
        public string NameClass
        {
            get
            {
                return _NameClass;
            }
            set
            {
                if (value != null)
                {
                    _NameClass = value;
                    OnPropertyChanged();
                }
            }
        }
        string _RegisterDay;
        public string RegisterDay
        {
            get
            {
                return _RegisterDay;
            }
            set
            {
                if (value != null)
                {
                    _RegisterDay = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Gender;
        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                if (value != null)
                {
                    _Gender = value;
                    OnPropertyChanged();
                }
            }

        }

        public string StudentTittle { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}