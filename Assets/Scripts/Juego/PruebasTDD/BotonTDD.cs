using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BotonTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CuandoPresionenElBoton_DebeActualizarseLaUIConLoQueTraeDelServiceLocator()
        {
            //arrage
            ServiceLocator.Instance.ClearAll();
            var logicaDeCalculos = Substitute.For<ILogicaDeCalculoDePuntuaciones>();
            logicaDeCalculos.AumentarPuntuacion().Returns(2);

            ServiceLocator.Instance.RegisterService(logicaDeCalculos);

            var subAccionMono = Substitute.For<IAccionDelBotonMono>();
            var area = Substitute.For<ICalculoDeArea>();
            Boton boton = new Boton(subAccionMono, area)
            {
                TiempoQueTieneQueDejarDePrecionarElBoton = 2,
                CadaCuantosPuntos = 1
            };

            //act
            boton.AumentandoPuntuacion();

            //assert
            subAccionMono.Received(1).ActualizarPuntuacion(2);
        }

        [Test]
        public void CuandoPresionenElBoton_DebeGuardarLocalmenteSinImportarCuantasVecesLeDemos()
        {
            //arrage
            ServiceLocator.Instance.ClearAll();
            var logicaDeCalculos = Substitute.For<ILogicaDeCalculoDePuntuaciones>();
            logicaDeCalculos.AumentarPuntuacion().Returns(2);

            ServiceLocator.Instance.RegisterService(logicaDeCalculos);

            var subAccionMono = Substitute.For<IAccionDelBotonMono>();
            var area = Substitute.For<ICalculoDeArea>();
            Boton boton = new Boton(subAccionMono, area)
            {
                YaGuardoData = false,
                TiempoQueTieneQueDejarDePrecionarElBoton = 2,
                CadaCuantosPuntos = 1
            };

            //act
            boton.AumentandoPuntuacion();
            boton.AumentandoPuntuacion();

            //Assert
            logicaDeCalculos.Received(2).ActualizarPuntuacion(2);

        }
        
    }
}
