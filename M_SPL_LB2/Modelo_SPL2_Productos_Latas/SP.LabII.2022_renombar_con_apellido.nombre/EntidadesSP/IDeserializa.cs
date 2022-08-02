using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///#.-IDeserializa<T> (tendrá como restricción que la clase posea un constructor por defecto)
    ///             -> Xml(out T) : bool
    ///             -> Json(out T) : bool
    public interface IDeserializa<T>
    {
        bool Xml(out T elemento);
        bool Json(out T elemento);
    }
}
