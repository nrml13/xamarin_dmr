using App4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            //Partie pour la restauration de l'état précedent
            if (App.Current.Properties.ContainsKey(LoginPageViewModel.ViewModelKey))
            {
                String s = App.Current.Properties[LoginPageViewModel.ViewModelKey].ToString();
                try
                {
                    BindingContext = JsonConvert.DeserializeObject<LoginPageViewModel>(s);
                }
                catch (Exception)
                {
                    this.BindingContext = new LoginPageViewModel();
                }
            }
            else
            {
                this.BindingContext = new LoginPageViewModel();
            }

            //A la création on dit que la page en cours est celle ci
            App.PageEnCours = this.GetType().ToString();
        }

        private void InitMessages()
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassword());
        }
    }
}
