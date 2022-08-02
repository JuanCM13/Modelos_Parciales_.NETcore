using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnityTests_Final
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(EntidadesFinal.BusinessException))]
        public void PruebaCreacionPersonaje_NivelErroneo_SeEsperaExcepcionTipoBusiness()
        {
            EntidadesFinal.Hechicero hech;

            hech = new EntidadesFinal.Hechicero(3, "asdad", -4);

            Console.WriteLine("Fallo la prueba, no retorno excepcion");
        }

        [TestMethod]

        public void PruebaAtaque_SeEsperaQueLosPuntosDeVidaNoSeanMenoresAcero()
        {
            EntidadesFinal.Hechicero h1 = new EntidadesFinal.Hechicero(1, "asda", 3);

            Console.WriteLine($"Puntos de vida antes: {h1.PuntosDeVida}");
            h1.RecibirAtaque(85000);            

            Console.WriteLine($"Puntos de vida despues: {h1.PuntosDeVida}");
            Assert.AreEqual(h1.PuntosDeVida, 0);
        }

        [TestMethod]
        public void PruebaPuntosDefensa_SeEspera_AreEqualTrue()
        {
            short nivel = 3;
            Int32 puntosHechiceroEsperados;
            Double puntosGuerreroEsperados;
            EntidadesFinal.Hechicero h1 = new EntidadesFinal.Hechicero(1, "asda", nivel);
            EntidadesFinal.Guerrero g1 = new EntidadesFinal.Guerrero(2, "gsgsgs", nivel);

            puntosHechiceroEsperados = nivel*100;
            puntosGuerreroEsperados = (nivel * 100) + ((nivel * 100) * 0.10);

            Console.WriteLine($"Puntos de defensa esperados del hechicero: {puntosHechiceroEsperados} -- obtenidos: {h1.PuntosDeDefensa}");
            Console.WriteLine($"Puntos de defensa esperados del Guerrero: {puntosGuerreroEsperados} -- obtenidos: {g1.PuntosDeDefensa}");
            Assert.AreEqual(puntosHechiceroEsperados, h1.PuntosDeDefensa);
            Assert.AreEqual(puntosGuerreroEsperados, g1.PuntosDeDefensa);
        }
    }
}
