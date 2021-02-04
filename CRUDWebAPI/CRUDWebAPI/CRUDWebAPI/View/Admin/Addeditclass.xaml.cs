using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Addeditclass : ContentPage
    {
        public Addeditclass(ClassStudent classStudent)
        {
            InitializeComponent();
            BindingContext = new AddClassViewModel(Navigation,classStudent);
        }


        public string ngaybatdau;

        public string ngayketthuc;
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            ngaybatdau = e.OldDate.ToString("dd-MM-yyyy");
            Preferences.Set("my_key4", ngaybatdau);
        }

        private void DatePicker_DateSelected_1(object sender, DateChangedEventArgs e)
        {
            ngayketthuc = e.OldDate.ToString("dd-MM-yyyy");
            Preferences.Set("my_key5", ngayketthuc);
        }
      
    }
}