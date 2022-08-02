using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///#.-IDeserializa -> Xml(out zapato) : bool
    public interface IDeserializa
    {
        bool Xml(out Zapato zapato);
    }
}
