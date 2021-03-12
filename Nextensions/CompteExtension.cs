using System;
using System.Collections.Generic;
using System.Text;

namespace TpBanqueV1.Nbanque
{
    static class CompteExtension
    {
        public static void DebitDiffere ( this Compte cpt , double montant , string date)
        {
            cpt.Debiter(300); 
        }

        public static void extensionChaine (this string str)
        {
            Console.WriteLine("extension chaine juste pour test "); 
        }
    }
}
