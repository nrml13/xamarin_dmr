using App4.Interfaces;
using App4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace App4.ViewModels
{
    class Page2ViewModel : ViewModelBase
    {
        //UTILISATEUR UTILISER UNIQUEMENT ICI
        public class UtilisateurVM : ViewModelBase
        {
            private String _NomUtilisateur;
            public String NomUtilisateur
            {
                get { return _NomUtilisateur; }
                set { RaisePropertyChanged(ref _NomUtilisateur, value); }
            }

            private Int32 _Age;
            public Int32 Age
            {
                get { return _Age; }
                set { RaisePropertyChanged(ref _Age, value); }
            }

        }

        //PROPRIETE
        public Command RefreshCommand { get; set; }

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

        private Boolean _IsRefreshing;
        public Boolean IsRefreshing
        {
            get { return _IsRefreshing; }
            set { RaisePropertyChanged(ref _IsRefreshing, value); }
        }

        ////Version N°1 de l'observable collection (avec utilisateur)
        //private ObservableCollection<Utilisateur> _ListeUsers = new ObservableCollection<Utilisateur>(UtilisateurManager.GetFakeUtilisateurs());
        //public ObservableCollection<Utilisateur> ListeUsers
        //{
        //    get { return _ListeUsers; }
        //    set { RaisePropertyChanged(ref _ListeUsers, value); }
        //}

        
        //Version N°2 de l'observable collection (avec utilisateurVM, la nested class)
        private ObservableCollection<UtilisateurVM> _ListeUsers = new ObservableCollection<UtilisateurVM>();
        public ObservableCollection<UtilisateurVM> ListeUsers
        {
            get { return _ListeUsers; }
            set { RaisePropertyChanged(ref _ListeUsers, value); }
        }


        //Instantiacion de l'ioc (Inversion of Control)  (role de connecteur entre l'app et le système)
        IPlatformInfo platInfo = DependencyService.Get<IPlatformInfo>();


        //CONSTRUCTEUR
        public Page2ViewModel()
        {
            //Recuperation des infos via l'ioc (Inversion of Control)
            Model = platInfo?.GetModel();
            Version = platInfo?.GetVersion();

            InitCommand();

            //Boucle pour passer des Utilisateurs aux UtilisateursVM
            foreach (Utilisateur item in UtilisateurManager.GetFakeUtilisateurs())
            {
                ListeUsers.Add(new UtilisateurVM() { NomUtilisateur = item.NomUtilisateur, Age = DateTime.Now.Year - item.DateDeNaissance.Year });
            }
        }

        private void InitCommand()
        {
            //Commande lors du refresh (scroll vers le haut quand deja top)
            RefreshCommand = new Command(() =>
            {
                ////Ajouter un element au refresh
                //ListeUsers.Insert(0, new Utilisateur { NomUtilisateur = "OBI-1" });

                ////Supprimer un element
                //ListeUsers.RemoveAt(0);

                ////Modifier un element
                //ListeUsers[0].NomUtilisateur = "Aragorn";

                IsRefreshing = false;
            });
        }

    }
}
