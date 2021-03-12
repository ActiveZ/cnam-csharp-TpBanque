using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpBanqueV1.Nclients;

namespace TpBanqueV1.Nbanque
{
    class CompteCourant : Compte 
    {
        public int MontantDecouvert { get; set;  }

        public CompteCourant (Client titulaire, string numero, double solde, string dateCreation , int montantDecouvert )
               : base ( titulaire , numero , solde , dateCreation)
        {
            MontantDecouvert = montantDecouvert; 
        }

        public CompteCourant(Client titulaire, string numero)
              : base(titulaire, numero)
        {
            MontantDecouvert = 200 ;
        }

        public CompteCourant() { }


        // Reprendre le traitement l'erreur 
        // réaliser à l'aide des exceptions 

        public override void Debiter(double montant)
        {
            if (montant <= _solde + MontantDecouvert)
            {
                _solde -= montant;
                AjouterOperation(Toperation.Credit, montant);
            }
            else
                throw new InvalideSoldeException($"Debit de {montant} impossible sur compte {Numero}");
              
        }

        public override string ToString() => $"{base.ToString()} {MontantDecouvert}"; 
      
    }
}
