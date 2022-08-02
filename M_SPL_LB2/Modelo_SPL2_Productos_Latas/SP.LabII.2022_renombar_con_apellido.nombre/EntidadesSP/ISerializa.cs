using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///#.-ISerializa -> Xml() : bool
    ///              -> PathXml{ get; } : string
    ///              -> Json() : bool
    ///              -> PathJson{ get; } : string
    public interface ISerializa
    {
        bool Xml();

        String PathXml { get; }

        bool Json();

        String PathJson { get; }
    }
}
