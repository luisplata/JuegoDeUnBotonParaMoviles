using System;
using UnityEngine;

public interface IAccionDelBotonMono
{
    void ActualizarPuntuacion(int puntuacion);
    void ReinciarTiempoDeEspera();
    void PonerBailarDancers();
    void InstanciarDancer(Vector2 crearObjectoDentroDelCuadrado);
}
