using System;

namespace EntidadesFinal
{
    /*
     * Crear un proyecto del tipo Biblioteca de Clases y agregarle los siguientes elementos:
        Excepción BusinessException
        Crear una excepción personalizada BusinessException con dos constructores, uno que reciba sólo el mensaje y otro que reciba además la InnerException.
        Enumerado LadosMoneda
        Tiene dos posible valores. Cara con valor 1 y Ceca con valor 2.
        Clase ExtensionRandom
        Extenderá el tipo Random y le agregará el método de extensión TirarUnaMoneda que retornará de forma aleatoria alguno de los valores del enumerado LadosMoneda.
     */
    public class BusinessException : Exception
    {
        public BusinessException()
            :this("Excepcion de tipo Business")
        { }

        public BusinessException(String mensaje)
            : this(mensaje,null)
        { }

        public BusinessException(String mensaje,Exception inner)
            : base("Excepcion de tipo Business",inner)
        { }
    }
}
