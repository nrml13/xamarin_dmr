using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Ceci est un POCO (ou s'en rapproche !), en gros cela veux dire que cette classe ne contient que des propriétés
/// </summary>


namespace App4.Models
{
    public class Utilisateur
    {
        public String NomUtilisateur { get; set; }
        public String MotDePasse { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public List<String> Maladies { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return NomUtilisateur;
        }
    }
}
