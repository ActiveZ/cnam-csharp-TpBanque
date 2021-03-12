using System;
using System.Collections.Generic;
using System.Text;

namespace TpBanqueV1.Nclients
{

    class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get ; set ;}

       public Client(string nom, string prenom, string email, string telephone , DateTime dateNaissance) =>
               (Nom, Prenom, Email, Telephone , DateNaissance ) = (nom, prenom, email, telephone, dateNaissance);

       public Client() { }

       public int GetAge ( )
       {
            //string str = null; 
            //DateTime test = null; 
            DateTime dateCourante = DateTime.Now;
            int age = dateCourante.Year - DateNaissance.Year;
            if (dateCourante.AddYears(-age) < DateNaissance)
                age--;
            return age; 
       }

       public override string ToString() => $"{Nom} {Prenom} {Email} {Telephone} {DateNaissance}"; 
    }
}

