using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpBanqueV1.Nclients;

namespace TpBanqueV1.Nbanque
{
    class CompteEpargne : Compte 
    {
        public double Interet { get; set; }

        public double Taux { get; set;  }

        public int Duree { get; set; }
        
        public CompteEpargne(Client titulaire, string numero, double solde, string dateCreation, int duree , double taux )
                :base(titulaire, numero, solde, dateCreation)
        {
            Taux = taux;
            Duree = duree; 
        }

        public CompteEpargne(Client titulaire, string numero)
              : base(titulaire, numero)
        {
            Taux = 0.05;
            Duree = 7;
        }

        public CompteEpargne() { }

        public override void Debiter(double montant)
        
        {
            DateTime dateCourante = DateTime.Now;
            int dureeEcoulee = dateCourante.Year - DateCreation.Year;
            if (dateCourante.AddYears(-dureeEcoulee) < DateCreation)
                dureeEcoulee--;
            if (montant <= _solde && Duree < dureeEcoulee )
            {
                _solde -= montant;
                AjouterOperation(Toperation.Credit, montant);
            }
            else
                
                throw new InvalideSoldeException($"Debit de {montant} impossible sur compte {Numero}");
        }

        public void CalculInteret ()
        {
            // Voir spécialiste Charlie 
            Interet = _solde * Taux;
            _solde += Interet; 
        }


        public override string ToString() => $"{base.ToString()} {Duree} {Taux} {Interet} ";

    }
}
