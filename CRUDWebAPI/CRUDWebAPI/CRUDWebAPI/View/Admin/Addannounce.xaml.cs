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
    public partial class Addannounce : ContentPage
    {
        public Addannounce(Thongbao thongbao)
        {
            InitializeComponent();
            BindingContext = new AddThongbaoViewModel(Navigation, thongbao);
        }
    }
}