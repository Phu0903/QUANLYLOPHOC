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
    public partial class ListClassTeacher : ContentPage
    {
        public ListClassTeacher()
        {
            InitializeComponent();
            BindingContext = new ListClassViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as ListClassViewModel).GetClassStudent2();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnnouncePage());
        }
    }
}