﻿using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using imPACt.Tables;

namespace imPACt
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        //current user logged in so this can be used throughout the app to grab current user
        public static RegisterUserTable currentUser { get; set; }

        //database to call methods to delete, update ...
        static LocalDatabase database;

        //Singleton to check if path for database has been set and if it has to return database
        public static LocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
                }
                return database;
            }
        }


        public App()
        {
            //_connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            //Checking if user is logged in 
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new imPACt.MainPage());
            }
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
