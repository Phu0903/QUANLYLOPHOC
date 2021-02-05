
using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTeacher : ContentPage
    {
        
        public ListTeacher()
        {
            InitializeComponent();

            BindingContext = new ListTeacherViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as ListTeacherViewModel).GetListTeacher();
        }


    }
 
}