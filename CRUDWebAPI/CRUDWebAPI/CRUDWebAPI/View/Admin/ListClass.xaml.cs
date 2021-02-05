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
    public partial class ListClass : ContentPage
    {
        public ListClass()
        {
            InitializeComponent();
            BindingContext = new ListClassViewModel(Navigation,1);
        }
        protected override void OnAppearing()
        {
            (this.BindingContext as ListClassViewModel).GetClassStudent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnnouncePage());
        }
    }
    
}