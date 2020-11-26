using System;

public class Boton
{
    private IAccionDelBotonMono accionDelBotonMono;

    public Boton(IAccionDelBotonMono accionDelBotonMono)
    {
        this.accionDelBotonMono = accionDelBotonMono;
    }

    public void AumentandoPuntuacion()
    {
        int puntuacion = ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().AumentarPuntuacion();
        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
        accionDelBotonMono.ReinciarTiempoDeEspera();
    }

    public void TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(float deltaTimeLocal, float tiempoQueTieneQueDejarDePrecionarElBoton, bool yaGuardoData)
    {
        if (deltaTimeLocal >= tiempoQueTieneQueDejarDePrecionarElBoton && !yaGuardoData)
        {
            accionDelBotonMono.YaGuardoData = true;
        }
    }
}