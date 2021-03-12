using System;
using TpBanqueV1.Nbanque;
using TpBanqueV1.Nclients;
//using UtilitaireDll.Nutil;

namespace TpBanqueV1
{
    class Program
    {
        public static void TestClient ()
        {
            Client c1 = new Client("nom1", "prenom1", "nom1@gmail.com", "0202020202" , new DateTime ( 1991 , 06 , 02));
            Client c2 = new Client() { Nom = "nom2", 
                                       Prenom = "prenom2" };
            Console.WriteLine(c1.GetAge()); 
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2); 
        }

        //public static void TestCompte ()
        //{
        //    Client c1 = new Client("nom1", "prenom1", "nom1@gmail.com", "0202020202", new DateTime(1991, 06, 02));
        //    Client c2 = new Client("nom2", "prenom2", "nom2@gmail.com", "0202020202", new DateTime(1991, 06, 02));
        //    Compte cpt1, cpt2;
        //    cpt1 = new Compte(c1, "101" , 500 , "2021-03-01");
        //    cpt2 = new Compte(c2, "102");
        //    cpt1.Crediter(100000);
        //    for (int i = 0; i < 15; i++)
        //        cpt1.Crediter(100 + i); 
        //    cpt2.Crediter(300);
        //    if (cpt2.Debiter(500))
        //        Console.WriteLine("Debit impossible");
        //    Console.WriteLine(cpt1.Solde);
        //    Console.WriteLine(cpt2.Solde);
        //    Transaction.Virement(cpt1, cpt2, 100); 
        //    Console.WriteLine(cpt1.ToString());
        //    Console.WriteLine(cpt2.ToString());
        //    Console.WriteLine(cpt1.GetHistorique());    
        //    //cpt1.DebitDiffere(100 , "2021-04-01"); 
        //    // appel implicite du deconstructeur 
        //    //(string num, double solde, _) = cpt1;
        //    //Console.WriteLine($"Info du compte cpt1 : {num} {solde}");
        //}

        public static void TestCompteCourant()
        {
            Client c1 = new Client("nom1", "prenom1", "nom1@gmail.com", "0202020202", new DateTime(1991, 06, 02));
            CompteCourant cpt1;
            cpt1 = new CompteCourant(c1, "101", 500, "2021-03-01" , 200);
            cpt1.Crediter(200);
            cpt1.Debiter(800);
            Console.WriteLine(cpt1); 
        }

        public static void TestCompteEpargne()
        {
            Client c1 = new Client("nom1", "prenom1", "nom1@gmail.com", "0202020202", new DateTime(1991, 06, 02));
            CompteEpargne cpt1;
            cpt1 = new CompteEpargne(c1, "101", 500, "2012-03-01", 7 , 0.07);
            cpt1.Crediter(200);
            cpt1.Debiter(300);
            Console.WriteLine(cpt1);
        }

        public static void TestBanque ()
        {
            Client c1 = new Client("nom1", "prenom1", "nom1@gmail.com", "0202020202", new DateTime(1991, 06, 02));
            Client c2 = new Client("nom2", "prenom2", "nom2@gmail.com", "0202020202", new DateTime(1991, 06, 02));
            Client c3 = new Client("nom3", "prenom3", "nom3@gmail.com", "0202020202", new DateTime(1991, 06, 02));
            Banque b = new Banque();
            b.CreerCompteCourant(c1);
            b.CreerCompteEpargne(c2);
            b.CreerCompteCourant(c3);
            Console.WriteLine(b.GetComptes());
            Compte cpt = b.RechercherCompte("101");
            cpt.Crediter(300);
            try
            {
                cpt.Debiter(1400);
            } catch ( InvalideSoldeException ex )
            {
                Console.WriteLine(ex.Message);
            }
            for (int i = 0; i < 15; i++)
                cpt.Crediter(100 + i);
            Console.WriteLine(cpt.GetHistorique(105)); 
            //Console.WriteLine("Solde en dollars : " + UtilConversion.ConversionDollars (cpt.Solde));
            Console.WriteLine(cpt.GetHistorique(Tcritere.date));
            if (cpt != null)
                Console.WriteLine("Resultat recherche " + cpt);
            else
                Console.WriteLine("Compte non trouvé");

            b.SupprimerCompte("102");
            Console.WriteLine(b.GetComptes());
        }


        static void Main(string[] args)
        {
            //TestCompte(); 
            //TestClient(); 
            //TestCompteEpargne(); 
            TestBanque(); 
        }
    }
}
