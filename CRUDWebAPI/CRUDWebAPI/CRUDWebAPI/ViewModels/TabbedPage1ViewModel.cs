using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    public class TabbedPage1ViewModel
    {
       
        public INavigation Navigation { get; set; }
        public TabbedPage1ViewModel(INavigation _navigation, string UserName_temp, string Password_temp)
        {
            Navigation = _navigation;
            
           
        }
    }
}
