using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Models
{
    class UtilisateurManager
    {
        public static Utilisateur GetFakeUtilisateur()
        {
            return new Utilisateur()
            {
                NomUtilisateur = String.Concat("N", DateTime.Now.Millisecond.ToString()),
                MotDePasse = String.Concat("N", DateTime.Now.Millisecond.ToString()),
                DateDeNaissance = DateTime.Now,
                Maladies = new List<string>()
            };
        }

        public static List<Utilisateur> GetFakeUtilisateurs(Int32 nombre = 200)
        {
            List<Utilisateur> listeUtilisateur = new List<Utilisateur>();
            for (int numeroUtilisateur = 0; numeroUtilisateur < nombre; numeroUtilisateur++)
            {
                listeUtilisateur.Add(GetFakeUtilisateur());
            }
            return listeUtilisateur;
        }
    }
}
