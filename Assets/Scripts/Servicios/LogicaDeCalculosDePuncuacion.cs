using UnityEngine;

public class LogicaDeCalculosDePuncuacion : ILogicaDeCalculoDePuntuaciones
{
    private readonly string _puntuacion = "puntuacion";
    private IGuardadoLocalDeDatos _guardadoLocal;
    private int _multiplicador;

    public LogicaDeCalculosDePuncuacion(IGuardadoLocalDeDatos metodoDeGuardado)
    {
        _guardadoLocal = metodoDeGuardado;
        _multiplicador = 1;
    }

    public int AumentarPuntuacion()
    {
        var puntuacion = GetPuntuacion();

        puntuacion += 1 * Multiplicador();

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

    public void CambiarMultiplicador(int multiplicador)
    {
        _multiplicador = multiplicador;
    }

    public int Multiplicador()
    {
        return _multiplicador;
    }
}