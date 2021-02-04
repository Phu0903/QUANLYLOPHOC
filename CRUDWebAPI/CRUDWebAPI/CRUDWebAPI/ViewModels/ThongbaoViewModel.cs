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

namespace CRUDWebAPI.ViewModels
{
    public class ThongbaoViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
       
        public ThongbaoViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
           
        }
        public async void GetAnnounce()
        {
            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/getThongbao";
                var result = await client.GetStringAsync(uri);
                var ThongbaoList = JsonConvert.DeserializeObject<List<Thongbao>>(result);
                Thongbao = new ObservableCollection<Thongbao>(ThongbaoList);
                IsRefreshing = false;
            }
        }
        public Command AddAnnounce
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new Addannounce(null));
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
        Thongbao _selectedthongbao;
        public Thongbao SelectedThongbao
        {
            get
            {
                return _selectedthongbao;
            }
            set
            {
                _selectedthongbao = value;
                if (value != null)
                {
                    Navigation.PushAsync(new Addannounce(_selectedthongbao));
                }
                OnPropertyChanged();
            }
        }


        ObservableCollection<Thongbao> _thongbao;
        public ObservableCollection<Thongbao> Thongbao
        {
            get
            {
                return _thongbao;
            }
            set
            {
                _thongbao = value;
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