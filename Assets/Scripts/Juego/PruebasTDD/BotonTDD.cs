﻿using NSubstitute;
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
            Boton boton = new Boton(subAccionMono);

            //act
            boton.AumentandoPuntuacion();

            //assert
            subAccionMono.Received(1).ActualizarPuntuacion(2);
            subAccionMono.Received(1).ReinciarTiempoDeEspera();
        }

        [Test]
        public void CuandoPresionenElBoton_DebeGuardarSiEsTiempoDeHacerlo()
        {
            //arrage
            ServiceLocator.Instance.ClearAll();
            var logicaDeCalculos = Substitute.For<ILogicaDeCalculoDePuntuaciones>();
            logicaDeCalculos.AumentarPuntuacion().Returns(2);

            ServiceLocator.Instance.RegisterService(logicaDeCalculos);

            var subAccionMono = Substitute.For<IAccionDelBotonMono>();

            Boton boton = new Boton(subAccionMono)
            {
                //act
                YaGuardoData = false
            };

            boton.AumentandoPuntuacion();

            //Assert
            logicaDeCalculos.Received(1).ActualizarPuntuacion(2);
            boton.AumentandoPuntuacion();
            logicaDeCalculos.Received(1).ActualizarPuntuacion(2);

        }
        
    }
}
