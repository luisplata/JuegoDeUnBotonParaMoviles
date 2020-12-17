using UnityEngine;

public class ManejadorDeOpcionDeMenu : IManejadorDeOpcionesDeMenu
{
    private GameObject objetoCompletoDeMenu;
    private bool EstaPausado;

    public ManejadorDeOpcionDeMenu(GameObject objetoCompletoDeMenu)
    {
        this.objetoCompletoDeMenu = objetoCompletoDeMenu;
        EstaPausado = true;
    }

    public void UtilizarMenuDeOpciones()
    {
        objetoCompletoDeMenu.SetActive(EstaPausado);
        EstaPausado = !EstaPausado;
    }
}