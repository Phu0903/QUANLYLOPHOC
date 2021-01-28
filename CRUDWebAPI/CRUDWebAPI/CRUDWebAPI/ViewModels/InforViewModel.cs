using CRUDWebAPI.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI
{
    class InforViewModel : INotifyPropertyChanged
    {
        private INavigation navigation { get; set; }
        private string email;
        private string password;

        public InforViewModel(INavigation _navigation, string email, string password)
        {
            this.navigation = _navigation;
            this.email = email;
            this.password = password;
        }
        public async void GetInforTeacher()
        {
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetTeacherLogin?email=" + email.ToString() + "&password=" + password.ToString();
                //var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/GetTeacherLogin?email=phucotrhihamhoc@gmai.com.vn&password=123456789";
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
