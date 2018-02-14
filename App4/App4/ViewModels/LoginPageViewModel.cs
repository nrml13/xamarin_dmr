using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        //CONST VALUES
        public static string ViewModelKey = "LoginPageViewModel";   //Clef pour la sauvegarde de l'état dans les proprieties
        public static string LinksToForgotPassword = "LinksToForgotPassword";   //Clef pour le message de navigation


        /// PROPS
        private String _Username;
        public String Username
        {
            get { return _Username; }
            set {
                RaisePropertyChanged(ref _Username, value);
                LoginCommand?.ChangeCanExecute();
                if (RememberMe)
                {
                    NotifyChange();
                }
            }
        }

        private String _Password;
        public String Password
        {
            get { return _Password; }
            set {
                RaisePropertyChanged(ref _Password, value);
                if (RememberMe)
                {
                    NotifyChange();
                }
            }
        }

        private Boolean _RememberMe;
        public Boolean RememberMe
        {
            get { return _RememberMe; }
            set {
                RaisePropertyChanged(ref _RememberMe, value);
                if (!value)
                {
                    DeletePageHistory();
                }
                else
                {
                    NotifyChange();
                }
            }
        }


        /// COMMANDS
        [JsonIgnore]
        public Command LoginCommand { get; set; }
        [JsonIgnore]
        public Command ForgotPassCommand { get; set; }


        //CONSTRUCTOR
        public LoginPageViewModel()
        {
            InitCommandes();
            InitMessages();
        }

        //METHODES INIT
        private void InitCommandes()
        {
            LoginCommand = new Command(() =>
            {

            },
            () =>
            {
                return !Username.IsNullOrEmptyOrWhiteSpace();
            });

            ForgotPassCommand = new Command(() =>
            {
                Debug.WriteLine(RememberMe);
            });
        }

        private void InitMessages()
        {
            //TODO INITMESSAGE
        }


        //MESSAGES METHODES
        //Sert a envoyer un message (écouter par app.xaml.cs), message utilisé pour la sauvegarde de l'état du view model
        private void NotifyChange()
        {
            String ViewModelSerialized = JsonConvert.SerializeObject(this);
            MessagingCenter.Send("", LoginPageViewModel.ViewModelKey, ViewModelSerialized);
        }

        async private void DeletePageHistory()
        {
            if (App.Current.Properties.ContainsKey(LoginPageViewModel.ViewModelKey))
            {
                App.Current.Properties.Remove(LoginPageViewModel.ViewModelKey);
                await App.Current.SavePropertiesAsync();
            }
        }
    }
}
