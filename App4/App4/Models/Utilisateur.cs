using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Models
{
    public class Utilisateur
    {
        public String NomUtilisateur { get; set; }
        public String MotDePasse { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public List<String> Maladies { get; set; }
    }
}
