using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set {
                RaisePropertyChanged(ref _LastName, value);
                SaveCommand?.ChangeCanExecute();

                String vmSerialise = JsonConvert.SerializeObject(this);
                //Debugger.Break();

                MessagingCenter.Send("", "ViewModelChanged", vmSerialise);
            }
        }

        private Int32 _Age;
        public Int32 Age
        {
            get { return _Age; }
            set { RaisePropertyChanged(ref _Age, value); }
        }

        [JsonIgnore]
        public Command UpdateCommand { get; set; }
        [JsonIgnore]
        public Command SaveCommand { get; set; }
        public Boolean _clicked = false;

        public WelcomePageViewModel()
        {
            //LastName = "Obiwan";
            Age = 69;

            SaveCommand = new Command( () => 
            {
                //Code
                SaveCommand.ChangeCanExecute();

                //Envoie d'un message sur le serveur de message (avec 0 paramètre)
                //MessagingCenter.Send(this, "SauvegardeTerminee");

                //Envoie d'un message sur le serveur de message (avec 1 paramètre)
                //MessagingCenter.Send(this, "SauvegardeTerminee", DateTime.Now);

                //Envoie d'un message sur le serveur de message (avec plusieurs params)
                MessagingCenter.Send(this, "SauvegardeTerminee", 
                    new Tuple<DateTime, String>(DateTime.Now, "2 elements"));

            },
            () =>
            {
                return !LastName.IsNullOrEmptyOrWhiteSpace();
            });

            UpdateCommand = new Command(() =>
            {
                LastName = "Dath Vader";
            });
        }
    }
}
