using System;
using System.Threading.Tasks;

public class Boton
{
    private IAccionDelBotonMono accionDelBotonMono;

    public bool YaGuardoData { get; set; }

    private bool orientacion;

    public Boton(IAccionDelBotonMono accionDelBotonMono)
    {
        this.accionDelBotonMono = accionDelBotonMono;
        YaGuardoData = false;
        var puntuacion = ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().GetPuntuacion();
        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
    }


    public void AumentandoPuntuacion()
    {
        if (orientacion)
        {
            accionDelBotonMono.BailandoLeft();
        }
        else
        {
            accionDelBotonMono.BailandoRight();
        }
        orientacion = !orientacion;

        int puntuacion = ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().AumentarPuntuacion();

        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
        accionDelBotonMono.ReinciarTiempoDeEspera();

        ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().ActualizarPuntuacion(puntuacion);

        if (!YaGuardoData)
        {
            //TODO aqui hay que guardar pero en la nube
            YaGuardoData = true;
        }
        ContadorParaCentralizar().WrapErrors();
    }

    private async Task ContadorParaCentralizar()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        accionDelBotonMono.BailandoCenter();
    }

    public void TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(float deltaTimeLocal, 
        float tiempoQueTieneQueDejarDePrecionarElBoton)
    {
        if (deltaTimeLocal >= tiempoQueTieneQueDejarDePrecionarElBoton && YaGuardoData)
        {
            YaGuardoData = false;
        }
    }
}