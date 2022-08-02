using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLibraries;
using Files;
using System.IO;
using System;
using System.Text.Json;

namespace UnityTests_Final
{
    [TestClass]
    public class UnitTest1
    {
        /*19. Agregar 2 test unitarios:
        a. Solo SP: Intentar leer un archivo desde el escritorio:
        i. Dicho archivo será provisto por la mesa de profesores.
        ii. El resultado esperado será 12 positivos, 10 negativos y 13 abstenciones.
        b. Forzar, mediante el código presente en la descripción anterior, que se lance la excepción
        NoNecesitaDesempateException validar que suceda de forma correcta.
        c. Para que sea Ley:
        i. Crear un parlamento de 2 bancas.
        ii. Poner los votos de forma tal (positivo o negativo) que la votación esté empatada.
        iii. Llamar al método de desempate para ver que funcione de forma correcta.*/
        [TestMethod]
        public void TesteoLecturaArchivo_JsonDesktop_SeEspera_12P_10N_13A()
        {
            int vP = 12;
            int vN = 10;
            int vA = 13;
            string nombreA = "votacion_UnityTest.json";
            Parlamento<Senador> auxT;

            using(StreamReader stR = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreA)))
            {
                auxT = (Parlamento<Senador>)JsonSerializer.Deserialize(stR.ReadToEnd(), typeof(Parlamento<Senador>), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });                
            }

            Console.WriteLine($"Votos Positivos recuperados: {auxT.VotosAfirmativos}\n" +
                $"Votos Negativos recuperados: {auxT.VotosNegativos}\nVotos Abstenciones recuperados:" +
                $" {auxT.VotosAbstenciones}");
            Assert.AreEqual(vP, auxT.VotosAfirmativos);
            Assert.AreEqual(vN, auxT.VotosNegativos);
            Assert.AreEqual(vA, auxT.VotosAbstenciones);
        }
    }
}
