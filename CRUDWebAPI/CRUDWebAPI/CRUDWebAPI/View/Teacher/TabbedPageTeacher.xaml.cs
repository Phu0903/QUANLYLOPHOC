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
    
    public partial class TabbedPageTeacher : TabbedPage
    {
        string email_temp;
        string password_temp;
        public TabbedPageTeacher(string email, string Password)
        {
            
            InitializeComponent();
            email_temp = email;
            password_temp = Password;
        }
        

       
    }
    
   /* [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Infor : ContentPage
    {
        public Infor(string email, string password)
        {
            InitializeComponent();
            BindingContext = new InforViewModel(Navigation, email, password);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as InforViewModel).GetInforTeacher();
        }
    }*/
}
