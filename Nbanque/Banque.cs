using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpBanqueV1.Nclients;

/* Remplacer le tableau de type Compte par un dictionary 
 * le numero sera utilisé comme clé 
 * ajouter la suppression d'un compte en fonction du numéro 
 */

namespace TpBanqueV1.Nbanque
{
    class Banque
    {
        private int numeroCompte = 100;
        private int nbrCompte = 0;

        public Dictionary<string, Compte> ListeComptes { get; set; } = new Dictionary<string, Compte>();

        public void CreerCompteCourant ( Client client)
        {
            CompteCourant cpt;
            Trace.WriteLine("*** Creation d'un compte courant ***"); 
            cpt = new CompteCourant(client, numeroCompte.ToString());
            numeroCompte++;
            ListeComptes.Add(cpt.Numero , cpt);  
        }

        public void CreerCompteEpargne(Client client)
        {
            CompteEpargne cpt;
            cpt = new CompteEpargne(client, numeroCompte.ToString());
            numeroCompte++;
            ListeComptes.Add(cpt.Numero, cpt);
        }

        public string GetComptes ()
        {
            StringBuilder listing = new StringBuilder("Liste des comptes : \n");
            foreach ( Compte cpt  in ListeComptes.Values)
                listing.AppendLine (cpt.ToString());
            return listing.ToString(); 
        }

        public Compte RechercherCompte ( string numero )
        {
            if ( ListeComptes.ContainsKey( numero))
                return ListeComptes[numero];
            return null; 
        }

        // Completer la Banque 
        // RechercherCompte en fonction du nom du client 
        // V1 en mode Sql 
        // V2 en mode lambda

        public Compte RechercherCompteParNom(string nom)
        {
            return ListeComptes.Values
                        .Where(cpt => cpt.Titulaire.Nom == nom)
                        .FirstOrDefault(); 
        }

        // Rechercher de Compte(s) superieur à un solde donné
        // Trie sur le nom du titulaire 
        // récuperer le nom l'email et le solde 
        public List<Tuple<string,string,double>>RechercherCompteParSolde(double solde)
        {
            List<Tuple<string, string, double>> res = ListeComptes.Values
                .Where(c => c.Solde >= solde)
                .OrderBy(c => c.Titulaire.Nom)
                .Select(c => new Tuple<string, string, double>( c.Titulaire.Nom, c.Titulaire.Email, c.Solde ))
                .ToList();
            return res; 
        }


            // Rajouter une méthode GetInformationBanque : String 
            // somme des soldes 
            // solde max 
            // solde min 
            // moyenne 
        public string GetInformationBanque()
        {
            StringBuilder infosBanque = new StringBuilder("Information Banque : \n");
            var requete = ListeComptes.Values.Select(cpt => cpt.Solde);
            //double sommeV2 = ListeComptes.Values.Sum(c => c.Solde);
            //double sommeV3 = ListeComptes.Values.OfType<CompteCourant>().Sum( c=> c.Solde); 
            double somme = requete.Sum();
            infosBanque.AppendLine($"Somme des comptes {somme}"); 
            double moyenne = requete.Average();
            infosBanque.AppendLine($"Moyenne des comptes {moyenne}");
            double min = requete.Min();
            infosBanque.AppendLine($"Minimum des comptes {min}");
            double max = requete.Max();
            infosBanque.AppendLine($"Maximum des comptes {max}");
            return infosBanque.ToString(); 
        }


            public bool SupprimerCompte(string numero)
        {
            return ListeComptes.Remove(numero); 
        }
        public void CalculInteret ()
        {
            foreach (Compte cpt in ListeComptes.Values)
                if ( cpt is CompteEpargne)
                    ((CompteEpargne)cpt).CalculInteret(); 
        }
    }
}