using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpBanqueV1.Nbanque
{
    class InvalideSoldeException : Exception
    {
        public InvalideSoldeException () { }
        public InvalideSoldeException( string message ) : base ( message) { }
        public InvalideSoldeException(string message, Exception ex) : base(message, ex) { }  
    }
}
