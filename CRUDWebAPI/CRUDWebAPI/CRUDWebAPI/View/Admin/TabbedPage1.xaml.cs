using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CRUDWebAPI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        
        public TabbedPage1(string UserName_temp,string Password_temp)
        {
            InitializeComponent();
            var inputText = UserName_temp;
            var inputText2 = Password_temp;
            Preferences.Set("my_key", inputText);
            Preferences.Set("my_key2", inputText2);
            //BindingContext = new TabbedPage1ViewModel(Navigation, UserName_temp, Password_temp);


        }
    }

}
