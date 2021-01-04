using System;
using System.Threading.Tasks;

public class Boton
{
    private IAccionDelBotonMono accionDelBotonMono;

    public bool YaGuardoData { get; set; }
    public float TiempoQueTieneQueDejarDePrecionarElBoton { get; set; }
    public int CadaCuantosPuntos { get; set; }

    private ICalculoDeArea calculoArea;
    private float deltaTimeLocal;
    private int puntuacionLocal;

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
        puntuacionLocal++;
        accionDelBotonMono.ActualizarPuntuacion(puntuacion);
        ReinciarTiempoDeEspera();

        ServiceLocator.Instance.GetService<ILogicaDeCalculoDePuntuaciones>().ActualizarPuntuacion(puntuacion);

        if (!YaGuardoData)
        {
            //TODO aqui hay que guardar pero en la nube
            YaGuardoData = true;
        }
        if(puntuacionLocal % CadaCuantosPuntos == 0)
        {
            accionDelBotonMono.InstanciarDancer(calculoArea.CalcularPosicionDentroDelCuadrado());
        }

        accionDelBotonMono.PonerBailarDancers();
    }

    public void TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(float deltaTime)
    {
        deltaTimeLocal += deltaTime;
        if (deltaTimeLocal >= TiempoQueTieneQueDejarDePrecionarElBoton && YaGuardoData)
        {
            YaGuardoData = false;
            accionDelBotonMono.QuitarLosDemasDancers();
            puntuacionLocal = 0;
        }
    }

    public void ReinciarTiempoDeEspera()
    {
        deltaTimeLocal = 0;
    }
}