using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Addeditclass : ContentPage
    {
        public Addeditclass(ClassStudent classstudent)
        {
            InitializeComponent();
            BindingContext = new AddClassViewModel(Navigation, classstudent);

        }
    }
}