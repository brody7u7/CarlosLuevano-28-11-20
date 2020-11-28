using System;
using ToDoListBertoni.Services.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListBertoni
{
    public partial class App : Application
    {
        private static DBContext _dbContext;
        public static DBContext DBContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DBContext();
                }
                return _dbContext;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ToDoListItems());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
