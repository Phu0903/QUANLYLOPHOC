using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetaiinforTeacher : ContentPage
    {
        public DetaiinforTeacher(TeacherInfor teacherinfor)
        {
            InitializeComponent();
            BindingContext = new DetailInforTeacherViewModel(Navigation, teacherinfor);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as DetailInforTeacherViewModel).GetClassStudent();
        }
    }
}