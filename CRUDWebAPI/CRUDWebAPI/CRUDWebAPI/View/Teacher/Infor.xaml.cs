using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View.Teacher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Infor : ContentPage
    {
        public Infor()
        {
            InitializeComponent();
            BindingContext = new InforViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as InforViewModel).GetInforTeacher();
        }
    }
}