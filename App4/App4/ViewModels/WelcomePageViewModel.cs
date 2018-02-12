using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinProjectPOEC.ViewModels
{
    public class WelcomePageViewModel
    {
        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private Int32 _Age;

        public Int32 Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public Command UpdateCommand { get; set; }

        public WelcomePageViewModel()
        {
            LastName = "Obiwan";
            Age = 69;
            UpdateCommand = new Command( () => 
            {
                LastName = "Darth Vader";
                Debugger.Break();

            });
        }
    }
}
