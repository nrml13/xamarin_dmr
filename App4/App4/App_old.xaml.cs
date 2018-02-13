using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using App4.Views;
using System.Diagnostics;

namespace App4
{
    public partial class App_old : Application
    {
        public static String PageEnCours { get; set; }
        public static String ViewModelEnCours { get; set; }

        public App_old()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<String, String>(this, "ViewModelChanged", async (sender, viewModel) =>
            {
                App.Current.Properties["ViewModelChanged"] = viewModel;
                await App.Current.SavePropertiesAsync();
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Debugger.Break();

            if (Application.Current.Properties.ContainsKey("DateSupsension"))
            {
                if (Application.Current.Properties.ContainsKey("ViewModelEnCours"))
                {
                    /////PAS TOUCHÉOU !!!
                    ////Demarage après destruction de l'appli
                    ////1 : recupèration du type de la derniere page au format string 
                    //string typeDeLaDernierePageString = Application.Current.Properties["PageEnCours"].ToString();
                    ////2 : recupèration du type de la dernière page (format type)
                    //Type typeDeLaDernierePage = Type.GetType(typeDeLaDernierePageString);
                    ////3 : création de la page (pour l'afficher) 
                    //MainPage = (Page)(Activator.CreateInstance(typeDeLaDernierePage));


                    MainPage = (Page)(Activator.CreateInstance(Type.GetType(Application.Current.Properties["ViewModelEnCours"].ToString())));

                }
            }
            else
            {
                //Demarage normal
                MainPage = new LoginPage();
            }
        }

        protected async override void OnSleep()
        {
            // Handle when your app sleeps
            Application.Current.Properties["DateSupsension"] = DateTime.Now;
            Application.Current.Properties["ViewModelEnCours"] = PageEnCours;
            await Application.Current.SavePropertiesAsync();

            //Debugger.Break();
        }

        protected async override void OnResume()
        {
            // Handle when your app resumes
            Application.Current.Properties.Remove("DateSuspension");
            await Application.Current.SavePropertiesAsync();

            //Debugger.Break();
        }
    }
}
