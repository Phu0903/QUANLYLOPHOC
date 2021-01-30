﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.ViewModels
{
    class ListTeacherViewModel
    {
        public string Text { get; set; }
        public INavigation Navigation { get; set; }
        public ListTeacherViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            Text = "First Childrent Page";
        }
    }
}
