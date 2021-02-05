using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    class AddEditClassViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        ClassStudent _classstudent;
        public AddEditClassViewModel(INavigation _navigation, ClassStudent classstudent)
        {
            Navigation = _navigation;
            _classstudent = classstudent;
            if (_classstudent != null)
            {
                
                NameClass = _classstudent.NameClass;
                StartDay = _classstudent.StartDay;
                LeavingDay = _classstudent.LeavingDay;
                ID_Teacher = _classstudent.ID_Teacher;
                ClassTittle = "Sửa thông tin lớp";
                IsVisibleDeleteBtn = true;
               
            }
            else
            {
                ClassTittle = "Thêm lớp";
            }
        }
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

        string _idteacher;
        public string ID_Teacher
        {
            get
            {
                return _idteacher;
            }
            set
            {
                /* try
                 {
                     _idteacher = int.Parse(value);
                 }
                 catch { _idteacher = null; }*/
                if (value != null)
                {
                    _idteacher = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ClassTittle { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
