using System;
using System.IO;
using System.Diagnostics;
using ToDoCP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoCP.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoCP
{
    public partial class App : Application
    {
        static DatabaseController database;

        public App()
        {
            //InitializeComponent();
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGren", Color.FromHex("6FA22F"));

            var nav = new NavigationPage(new ToDoListPage());
            nav.BackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
            //MainPage = new MainPage();
            //var todoListPage = new ToDoTaskPage();
        }

        public static DatabaseController Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

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
