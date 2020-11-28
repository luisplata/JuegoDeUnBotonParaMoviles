using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LogicaDePuntuacionTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CuandoAumentamosLaPuntuacion_DebeAumentarAcorde()
        {
            var subGuardado = Substitute.For<IGuardadoLocalDeDatos>();
            subGuardado.GetInt(Arg.Any<string>()).Returns(2);
            var logicaPuntuacuon = new LogicaDeCalculosDePuncuacion(subGuardado);

            //act
            var puntuacionActual = logicaPuntuacuon.AumentarPuntuacion();

            //assert
            Assert.AreEqual(3, puntuacionActual);
        }
        
    }
}
