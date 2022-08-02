using System;
using System.Text;
using EntidadesFinal;                                                                              

namespace Consola_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Personaje personaje1 = PersonajeDAO.ObtenerPersonajePorId(1);

                Personaje personaje2 = PersonajeDAO.ObtenerPersonajePorId(2);

                Personaje.AtaqueLanzado += Program.MostrarAtaqueLanzado;
                Personaje.AtaqueRecibodo += Program.MostrarAtaqueRecibido;
                Combate.RondaIniciada += Program.IniciarRonda;
                Combate.CombateFinalizado += Program.FinalizarCombate;

                Combate combate = new Combate(personaje1, personaje2);

                Console.WriteLine("¡FIGHT!");

                combate.IniciarCombate().Wait();
            }
            catch(BusinessException exB)
            {
                Console.WriteLine($"Error: {exB.Message}\n");
            }
            catch(Exception ex)
            {
                StringBuilder str = new StringBuilder().AppendLine($"Error: { ex.Message}\n");
                Exception auxRunner = ex.InnerException;
                if(auxRunner is not null)
                {
                    //str.Clear();
                    str.AppendLine("StackTrace: ");
                    while (!(auxRunner.InnerException is null))
                    {
                        str.AppendLine($"Stack: {auxRunner.Message}");
                        auxRunner = auxRunner.InnerException;
                    }
                    str.AppendLine($"Stack: {auxRunner.Message}");
                }
                
                Console.WriteLine($"StackTrace: {str}");
                Logger logg = new Logger("log.txt");
                logg.GuardarLog(str.ToString());
            }
        }

        static void IniciarRonda(IJugador atacante, IJugador atacado)
        {            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"¡{atacante} ataca a {atacado}!");
        }

        static void FinalizarCombate(IJugador ganador)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
        }

        static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
        }

        static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos. Le quedan {personaje.PuntosDeVida} puntos de vida.");
        }
    }
}
