using CRUDWebAPI.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    class AddClassViewModel:INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        ClassStudent _class;
       // string StartDay = Preferences.Get("my_key4", "default_value");
        string _startday;
        public string StartDay
        {
            get
            {
                return _startday;
            }
            set
            {
                if (value != null)
                {
                    _startday = value;
                    OnPropertyChanged();
                }
            }
        }
        string _leavingday;
        public string LeavingDay
        {
            get
            {
                return _leavingday;
            }
            set
            {
                if (value != null)
                {
                    _leavingday = value;
                    OnPropertyChanged();
                }
            }
        }
       // string LeavingDay = Preferences.Get("my_key5", "default_value");
        public AddClassViewModel(INavigation _navigation, ClassStudent classStudent)
        {
            Navigation = _navigation;
            _class = classStudent;
            if (_class != null)
            {

               
                NameClass = _class.NameClass;
                ID_CLass = _class.ID_CLass;
                ID_Teacher = _class.ID_Teacher;
                StartDay = _class.StartDay;
                LeavingDay = _class.LeavingDay;
                ClassTittle = "Sửa thông tin lớp";
                IsVisibleDeleteBtn = true;
            }
            else
            {
                ClassTittle = "Thêm thông tin lớp";
            }
        }

        public Command Saveclass
        {
            get
            {
                return new Command(async () =>
                {
                    if (_class != null)
                    {
                        _class.NameClass = NameClass;
                        _class.ID_CLass = ID_CLass;
                        _class.ID_Teacher = ID_Teacher;
                        _class.StartDay = StartDay;
                        _class.LeavingDay = LeavingDay;
                    }
                    else
                    {
                        _class = new ClassStudent();
                        _class.NameClass = NameClass;
                        _class.ID_CLass = ID_CLass;
                        _class.ID_Teacher = ID_Teacher;
                        _class.StartDay = StartDay;
                        _class.LeavingDay = LeavingDay;
                    }
                    string url = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/SaveClass";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_class);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (responseData.Status == 1)
                    {
                        if (IsVisibleDeleteBtn == true)
                        {
                            for (var counter = 1; counter < 2; counter++)
                            {
                                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                            }
                            await Navigation.PopAsync();
                        }
                        else await Navigation.PopAsync();


                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Message", responseData.Message, "ok");
                    }
                });
            }
        }
        public Command Deleteclass
        {
            get
            {
                return new Command(async () =>
                {
                    string url = $"https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/DeleteClass?ClassID={_class.ID_CLass}";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_class);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    string result = await response.Content.ReadAsStringAsync();
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (responseData.Status == 1)
                    {
                        for (var counter = 1; counter < 2; counter++)
                        {
                            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                        }
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

        string _nameclass;
        public string NameClass
        {
            get
            {
                return _nameclass;
            }
            set
            {
                if (value != null)
                {
                    _nameclass = value;
                    OnPropertyChanged();
                }
            }
        }

        string _idclass;
        public string ID_CLass
        {
            get
            {
                return _idclass;
            }
            set
            {
                if (value != null)
                {
                    _idclass = value;
                    OnPropertyChanged();
                }
            }
        }

      string _idteacher;
        public string ID_Teacher
        {
            get
            {
                return _idteacher;
            }
            set
            {
                if (value != null)
                {
                    _idteacher = value;
                    OnPropertyChanged();
                }
            }
        }
        /* string _startday;
        public string StartDay
        {
            get
            {
                return _startday;
            }
            set
            {
                if (value != null)
                {
                    _startday = value;
                    OnPropertyChanged();
                }
            }
        }
        string _leavingday;
        public string LeavingDay
        {
            get
            {
                return _leavingday;
            }
            set
            {
                if (value != null)
                {
                    _leavingday = value;
                    OnPropertyChanged();
                }
            }
        }*/
        /* string _RegisterDay;
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
         //string _Gender;
         //public string Gender
         //{
         //    get
         //    {
         //        return _Gender;
         //    }
         //    set
         //    {
         //        if (value != null)
         //        {
         //            _Gender = value;
         //            OnPropertyChanged();
         //        }
         //    }

         //}*/

        public string ClassTittle { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

