using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    /*
     * Implementa la interfaz IJugador.

        No se puede instanciar.

        Tendrá una propiedad Titulo de sólo escritura que cambia el valor del atributo titulo.

        El atributo random es estático y debe inicializarse en un constructor estático.

        Constructores de instancia:

        Todos los personajes arrancan con una base de:
        100 puntos de defensa por cada nivel que tenga el personaje.
        100 puntos de poder por cada nivel que tenga el personaje.
        500 puntos de vida por cada nivel que tenga el personaje.
        Si se usa la sobrecarga de constructores que no recibe un nivel, por defecto será 1.
        El constructor debe recibir un nombre que no sea null ni solamente espacio en blanco, de lo contrario lanzar la excepción ArgumentNullException (ya definida en .NET).
        Asegurarse de que el nombre proporcionado no tenga espacios en blanco al inicio o al final. Si los tuviera, eliminarlos del string.
        Inicializar el id con el argumento proporcionado.
        Valida que el nivel se encuentre entre el máximo y el mínimo permitidos (incluídos).
        El máximo de nivel deberá estar definido en una constante de la clase y será 100.
        El mínimo de nivel deberá estar definido en una constante de la clase y será 1.
        Si el nivel no es válido, lanzará la excepción personalizada BusinessException con un mensaje descriptivo.
        Dos personajes serán iguales sólo si tienen el mismo id. Cambiar el comportamiento por defecto de las operaciones de comparación: operador ==, método Equals y método GetHashCode.
     */

    public delegate void BusinessDelegate(Personaje p, Int32 i);

    public abstract class Personaje : IJugador
    {
        private const Int32 maximoNivel = 100;
        private const Int32 minimoNivel = 1;
        private Decimal id;
        private short nivel;
        private String nombre;
        protected Int32 puntosDeVida;
        protected Int32 puntosDeDefensa;
        protected Int32 puntosDePoder;
        private static Random random;
        private String titulo;
        public static event BusinessDelegate AtaqueLanzado;
        public static event BusinessDelegate AtaqueRecibodo;

        static Personaje()
        {
            Personaje.random = new Random();
        }

        public Personaje(Decimal id , String nombre)
            :this(id,nombre,1)
        {}

        public Personaje(Decimal id, String nombre , short nivel)
        {
            if(!(String.IsNullOrWhiteSpace(nombre)))
            {
                if(nivel <= Personaje.maximoNivel && nivel >= Personaje.minimoNivel)
                {
                    this.id = id;
                    this.nivel = nivel;
                    this.nombre = nombre.Trim();
                    Int32 puntosD_P = this.nivel * 100;
                    this.puntosDePoder = puntosD_P;
                    this.puntosDeDefensa = puntosD_P;
                    this.puntosDeVida = this.nivel * 500;
                    this.AplicarBeneficiosDeClase();
                }               
                else
                {
                    throw new BusinessException("Error, el nivel debe estar en el rango de 0 a 100 inclusive..");
                }
            }
            else
            {
                throw new ArgumentNullException("El nombre debe tener algo escrito!");
            }
            
        }

        public short Nivel
        {
            get 
            {
                return this.nivel;
            }
        }

        public Int32 PuntosDeVida
        {
            get 
            {
                return this.puntosDeVida;
            }
        }

        public Int32 PuntosDeDefensa
        {
            get { return this.puntosDeDefensa; }
        }


        public String Titulo { set { this.titulo = value; } }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            if(!(p1 is null) && !(p2 is null) && p1.id == p2.id)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if(!(obj is null) && obj is Personaje)
            {
                return ((Personaje)obj) == this;
            }
            return false;
        }

        protected abstract void AplicarBeneficiosDeClase();

        public Int32 Atacar()
        {
            /*Se detendrá el hilo de ejecución por un tiempo aleatorio de entre 1 y 5 segundos.
            Retornará los puntos de ataque que tendrán un valor de entre un 10 % y un 100 % de los puntos de poder. 
            El porcentaje a aplicar se debe definir de manera aleatoria.
            Por último, lanza el evento AtaqueLanzado pasándole como argumentos a la instancia del personaje que está atacando y 
            los puntos de ataque calculados. Sólo lanza el evento si el mismo tiene subscriptores.
            Al recibir un ataque:*/
            Thread.Sleep(Personaje.random.Next(1, 5));

            Int32 auxRet = (this.puntosDePoder * Personaje.random.Next(10, 100)) / 100;
            if(auxRet < 0)
            {
                auxRet = Math.Abs(auxRet);
            }

            if(!(Personaje.AtaqueLanzado is null))
            {
                Personaje.AtaqueLanzado.Invoke(this, auxRet);
            }        
            return auxRet;
        }

        public void RecibirAtaque(Int32 daño)
        {
            /*El personaje se defenderá restando a los puntos de ataque recibidos entre un 10% y un 100% de los puntos de defenza. 
             * El porcentaje a aplicar se debe definir de manera aleatoria.
                Una vez que se ejecutó la defenza, se restarán los puntos de ataque resultantes a los puntos de vida del personaje.
                Los puntos de vida no pueden quedar en negativo, el valor mínimo es cero.
                Por último, lanza el evento AtaqueRecibido pasándole como argumentos a la instancia del personaje que está recibiendo el 
                ataque y los puntos de ataque que impactaron efectivamente (luego de aplicar la defenza). Sólo lanza el evento si el mismo 
            tiene subscriptores. */
            Int32 auxRet = (this.puntosDePoder * Personaje.random.Next(10, 100)) / 100;
            Int32 dañoRecibido = daño - auxRet;

            if(dañoRecibido < 0)
            {
                dañoRecibido = 0;
            }
            /*else
            {
                this.puntosDeVida += (dañoRecibido);
            }*/
            this.puntosDeVida -= (dañoRecibido);

            if (this.puntosDeVida < 0)
            {
                this.puntosDeVida = 0;
            }
            if(!(Personaje.AtaqueRecibodo is null))
            {
                Personaje.AtaqueRecibodo.Invoke(this, dañoRecibido);
            }
        }

        public override string ToString()
        {
            return new StringBuilder().AppendLine($"Tipo Personaje: {this.GetType().Name}: Nombre: {this.nombre} -- Nivel: {this.Nivel} -- " +
                $"Puntos de Vida: {this.PuntosDeVida}").ToString();
        }
    }
}
