using System;
using System.Collections.Generic;
using System.Text;

namespace TpBanqueV1.Nbanque
{
    static class Transaction
    {
        public static void Virement ( Compte cpt1 , Compte cpt2 , double montant )
        {
            cpt1.Debiter(montant);
            cpt2.Crediter(montant); 
        }
    }
}
