using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View.Teacher
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class TabbedPageTeacher : TabbedPage
    {
        
        public TabbedPageTeacher(string UserName_temp, string Password_temp)
        {
            
            InitializeComponent();
            var inputText = UserName_temp;
            var inputText2 = Password_temp;
            Preferences.Set("my_key", inputText);
            Preferences.Set("my_key2", inputText2);
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
