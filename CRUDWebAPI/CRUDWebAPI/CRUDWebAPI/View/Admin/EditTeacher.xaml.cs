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
    public partial class EditTeacher : ContentPage
    {
        public EditTeacher(TeacherInfor teacherInfor)
        {
            InitializeComponent();
            BindingContext = new AddTeacherViewModel(Navigation, teacherInfor);
        }
    }
}