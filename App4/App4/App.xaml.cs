using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using App4.Views;
using System.Diagnostics;
using App4.ViewModels;

namespace App4
{
    public partial class App : Application
    {

        public static String PageEnCours { get; set; }
        public static String ViewModelEnCours { get; set; }

        public App()
        {
            InitializeComponent();
            //On s'abonne aux différents message de mise a jour des état des pages
            SubscribeToLoginPageViewModel();
        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey("DateSupsension"))
            {
                if (Application.Current.Properties.ContainsKey("PageEnCours"))
                {
                    /////PAS TOUCHÉOU !!!
                    ////Demarage après destruction de l'appli
                    ////1 : recupèration du type de la derniere page au format string 
                    //string typeDeLaDernierePageString = Application.Current.Properties["PageEnCours"].ToString();
                    ////2 : recupèration du type de la dernière page (format type)
                    //Type typeDeLaDernierePage = Type.GetType(typeDeLaDernierePageString);
                    ////3 : création de la page (pour l'afficher) 
                    //MainPage = (Page)(Activator.CreateInstance(typeDeLaDernierePage));

                    MainPage = new NavigationPage((Page)(Activator.CreateInstance(Type.GetType(Application.Current.Properties["PageEnCours"].ToString()))));
                }
            }
            else
            {
                //Demarage normal
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected async override void OnSleep()
        {
            //Sauvegarde de la date de suspension
            Application.Current.Properties["DateSupsension"] = DateTime.Now;
            //Sauvegarde du type de la page en cours
            Application.Current.Properties["PageEnCours"] = PageEnCours;
            await Application.Current.SavePropertiesAsync();
        }

        protected async override void OnResume()
        {
            //On supprimme la date de suspension
            Application.Current.Properties.Remove("DateSuspension");
            await Application.Current.SavePropertiesAsync();
        }

        //Abonnement pour permettre de sauvegarder l'état d'une viewModel dans les propriétés locales
        private void SubscribeToLoginPageViewModel()
        {
            MessagingCenter.Subscribe<String, String>(this, LoginPageViewModel.ViewModelKey, async (sender, viewModel) =>
            {
                App.Current.Properties[LoginPageViewModel.ViewModelKey] = viewModel;
                await App.Current.SavePropertiesAsync();
            });
        }
    }
}
