using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDWebAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ClassStudent classStudent)
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation, classStudent);
            
        }
       protected override void OnAppearing()
        {
            (this.BindingContext as MainPageViewModel).GetStudents();
        }
    }
}
