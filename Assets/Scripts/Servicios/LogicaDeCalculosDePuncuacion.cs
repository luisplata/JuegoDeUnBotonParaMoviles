using UnityEngine;

public class LogicaDeCalculosDePuncuacion : ILogicaDeCalculoDePuntuaciones
{
    private string _puntuacion = "puntuacion";

    public int AumentarPuntuacion()
    {
        var puntuacion = PlayerPrefs.GetInt(_puntuacion);
        puntuacion++;
        PlayerPrefs.SetInt(_puntuacion, puntuacion);
        return puntuacion;
    }

    public void ActualizarPuntuacion(int puntuacion)
    {
        PlayerPrefs.SetInt(_puntuacion, puntuacion);
    }

    public int GetPuntuacion()
    {
        return PlayerPrefs.GetInt(_puntuacion);
    }
}
