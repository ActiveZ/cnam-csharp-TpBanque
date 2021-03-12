using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpBanqueV1.Nbanque
{
    enum Toperation { Debit , Credit }; 

    class Operation : IComparable<Operation>
    {
        public Toperation Type { get; set;}
        public double Montant { get; set;}
        public DateTime Date { get; set;}
        public Operation(Toperation type, double montant, DateTime date) =>
               (Type, Montant, Date) = (type, montant, date); 
        public Operation () {}
        public override string ToString() => $"{Type} {Montant} {Date}";

        public int CompareTo(Operation other)
        {
            return Montant.CompareTo(other.Montant);
        }
    }
}