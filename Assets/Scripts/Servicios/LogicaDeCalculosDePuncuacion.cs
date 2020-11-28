using UnityEngine;

public class LogicaDeCalculosDePuncuacion : ILogicaDeCalculoDePuntuaciones
{
    private string _puntuacion = "puntuacion";
    private IGuardadoLocalDeDatos _guardadoLocal;

    public LogicaDeCalculosDePuncuacion(IGuardadoLocalDeDatos metodoDeGuardado)
    {
        _guardadoLocal = metodoDeGuardado;
    }

    public int AumentarPuntuacion()
    {
        var puntuacion = _guardadoLocal.GetInt(_puntuacion);
        puntuacion+=1;
        _guardadoLocal.SetInt(_puntuacion, puntuacion);
        return puntuacion;
    }

    public void ActualizarPuntuacion(int puntuacion)
    {
        _guardadoLocal.SetInt(_puntuacion, puntuacion);
    }

    public int GetPuntuacion()
    {
        return _guardadoLocal.GetInt(_puntuacion);
    }
}