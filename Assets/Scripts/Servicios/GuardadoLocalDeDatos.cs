using UnityEngine;

public class GuardadoLocalDeDatos : IGuardadoLocalDeDatos
{
    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public void SetInt(string key, int dato)
    {
        PlayerPrefs.SetInt(key, dato);
    }
}
