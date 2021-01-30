
using CRUDWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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


            /*ObservableCollection<TeacherInfor> teacher = new ObservableCollection<TeacherInfor>();

            teacher.Add(new TeacherInfor { Name = "khang", Phone = "0123456" });
            teacher.Add(new TeacherInfor { Name = "khoa", Phone = "0123456" });
            teacher.Add(new TeacherInfor { Name = "uyên", Phone = "0123456" });
            teacher.Add(new TeacherInfor { Name = "mai", Phone = "0123456" });
            teacher.Add(new TeacherInfor { Name = "cường", Phone = "0123456" });
            teacher.Add(new TeacherInfor { Name = "thảo", Phone = "0123456" });

            
            
            listView.ItemsSource = teacher;*/
            BindingContext = new ListTeacherViewModel(Navigation);
        }

       
    }
 
}