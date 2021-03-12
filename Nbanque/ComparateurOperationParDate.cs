using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpBanqueV1.Nbanque
{
    class ComparateurOperationParDate : IComparer<Operation>
    {
        public int Compare(Operation op1, Operation op2)
        {
            return op1.Date.CompareTo ( op2.Date);
        }
    }
}
