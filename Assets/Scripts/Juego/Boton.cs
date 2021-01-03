using System;
using System.Threading.Tasks;

public class Boton
{
    private IAccionDelBotonMono accionDelBotonMono;

    public bool YaGuardoData { get; set; }

    private bool orientacion;

    private ICalculoDeArea calculoArea;

    public Boton(IAccionDelBotonMono accionDelBotonMono, ICalculoDeArea area)
    {
        this.accionDelBotonMono = accionDelBotonMono;
        YaGuardoData = false;
        var puntuacion = ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().GetPuntuacion();
        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
        calculoArea = area;
    }

    public void AumentandoPuntuacion()
    {
        int puntuacion = ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().AumentarPuntuacion();

        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
        accionDelBotonMono.ReinciarTiempoDeEspera();

        ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().ActualizarPuntuacion(puntuacion);

        if (!YaGuardoData)
        {
            //TODO aqui hay que guardar pero en la nube
            YaGuardoData = true;
        }

        accionDelBotonMono.InstanciarDancer(calculoArea.CrearObjectoDentroDelCuadrado());

        accionDelBotonMono.PonerBailarDancers();
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