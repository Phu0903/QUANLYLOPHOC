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
    class AddThongbaoViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        Thongbao _thongbao;
        public AddThongbaoViewModel(INavigation _navigation, Thongbao thongbao)
        {
            Navigation = _navigation;
            _thongbao = thongbao;
            if (_thongbao != null)
            {

                Tieude = _thongbao.Tieude;
                NoiDung = _thongbao.NoiDung;
                ThongbaoTittle = "Sửa Thông báo";
                IsVisibleDeleteBtn = true;
            }
            else
            {
                ThongbaoTittle = "Thêm Thông báo";
            }
        }

        public Command SaveAnnounce
        {
            get
            {
                return new Command(async () =>
                {
                    if (_thongbao != null)
                    {
                        _thongbao.Tieude = Tieude;
                        _thongbao.NoiDung = NoiDung;
                    }
                    else
                    {
                        _thongbao = new Thongbao();
                        _thongbao.Tieude = Tieude;
                        _thongbao.NoiDung = NoiDung;
                    }
                    string url = "http://quanlylophoc.somee.com/api/Masters/SaveThongbao";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_thongbao);
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
        public Command DeleteAnnounce
        {
            get
            {
                return new Command(async () =>
                {
                    string url = $"https://xamarinwebapi-gj0.conveyor.cloud/api/Masters/DeleteThongbao?ThongbaoId={_thongbao.Id_thongbao}";
                    HttpClient client = new HttpClient();
                    string jsonData = JsonConvert.SerializeObject(_thongbao);
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

        string _tieude;
        public string Tieude
        {
            get
            {
                return _tieude;
            }
            set
            {
                if (value != null)
                {
                    _tieude = value;
                    OnPropertyChanged();
                }
            }
        }

        string _noidung;
        public string NoiDung
        {
            get
            {
                return _noidung;
            }
            set
            {
                if (value != null)
                {
                    _noidung = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ThongbaoTittle { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

