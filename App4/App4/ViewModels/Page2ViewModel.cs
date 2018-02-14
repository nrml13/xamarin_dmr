using App4.Interfaces;
using App4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace App4.ViewModels
{
    class Page2ViewModel : ViewModelBase
    {
        private String _Version;
        public String Version
        {
            get { return _Version; }
            set { RaisePropertyChanged(ref _Version, value); }
        }

        private String _Model;
        public String Model
        {
            get { return _Model; }
            set { RaisePropertyChanged(ref _Model, value); }
        }

        private List<Utilisateur> _ListeUsers = UtilisateurManager.GetFakeUtilisateurs();
        public List<Utilisateur> ListeUsers
        {
            get { return _ListeUsers; }
            set { RaisePropertyChanged(ref _ListeUsers, value); }
        }



        //Instantiacion de l'ioc (connecteur entre l'app et le système)
        IPlatformInfo platInfo = DependencyService.Get<IPlatformInfo>();

        public Page2ViewModel()
        {
            Model = platInfo?.GetModel();
            Version = platInfo?.GetVersion();
        }

    }
}
