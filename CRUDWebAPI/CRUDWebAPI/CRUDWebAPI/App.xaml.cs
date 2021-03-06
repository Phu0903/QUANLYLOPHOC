﻿using CRUDWebAPI.View;
using CRUDWebAPI.View.Admin;
using CRUDWebAPI.View.Teacher;
using CRUDWebAPI.Views.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CRUDWebAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "MediaElement_Experimental" });
            MainPage = new NavigationPage(new TeacherOrAdmin());
            //MainPage = new NavigationPage(new Infor());
            //MainPage = new NavigationPage(new TabbedPage1());
            //MainPage = new NavigationPage(new Addeditclass(null));


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
