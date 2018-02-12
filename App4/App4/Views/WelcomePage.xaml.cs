using App4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            if (App.Current.Properties.ContainsKey("ViewModelEnCours"))
            {
                //Object obj = App.Current.Properties["ViewModelEnCours"];
                //Debugger.Break();
                String s = App.Current.Properties["ViewModelEnCours"].ToString();
                try
                {
                    BindingContext = JsonConvert.DeserializeObject<WelcomePageViewModel>(s);
                }
                catch (Exception)
                {
                    this.BindingContext = new WelcomePageViewModel();
                }
            }
            else
            {
                this.BindingContext = new WelcomePageViewModel();
            }

            App.PageEnCours = this.GetType().ToString();

            ////Abonnement aux message envoyé par WelcomePageViewModel (ceux sans params)
            //MessagingCenter.Subscribe<WelcomePageViewModel>(this, "SauvegardeTerminee", 
            //    async (sender) =>
            //{
            //    await DisplayAlert("Info", "Sauvegarde terminée avec succès", "ookay");

            //    /////Désabonnement
            //    //MessagingCenter.Unsubscribe<WelcomePageViewModel>(this, "SauvegardeTerminee");
            //});

            ////Abonnement aux message envoyé par WelcomePageViewModel (ceux avec params)
            MessagingCenter.Subscribe<WelcomePageViewModel, Tuple<DateTime, String>>(this, "SauvegardeTerminee",
                async (sender, args) =>
                {
                    await DisplayAlert("Info", $"Sauvegarde terminée avec succès à {args.Item1}", "ookay");

                    ////Désabonnement
                    //MessagingCenter.Unsubscribe<WelcomePageViewModel, Tuple<DateTime, String>>(this, "SauvegardeTerminee");
                });
        }
    }
}
