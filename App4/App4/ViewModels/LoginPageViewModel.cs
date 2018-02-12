using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        /// PROPS
        private String _Username;
        public String Username
        {
            get { return _Username; }
            set {
                RaisePropertyChanged(ref _Username, value);
                LoginCommand?.ChangeCanExecute();
            }
        }

        private String _Password;
        public String Password
        {
            get { return _Password; }
            set { RaisePropertyChanged(ref _Password, value); }
        }

        
        /// COMMANDS
        [JsonIgnore]
        public Command LoginCommand { get; set; }
        [JsonIgnore]
        public Command ForgotPassCommand { get; set; }


        //CONSTRUCTOR
        public LoginPageViewModel()
        {
            LoginCommand = new Command(() =>
            {
                LoginCommand.ChangeCanExecute();
            },
            () =>
            {
                return !Username.IsNullOrEmptyOrWhiteSpace();
            });

            ForgotPassCommand = new Command(() =>
            {

            });
        }
    }
}
