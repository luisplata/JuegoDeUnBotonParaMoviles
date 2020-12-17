using UnityEngine;
using UnityEngine.UI;

public class InstalerServiceLocator : MonoBehaviour
{
    [SerializeField] private string titlId;
    [SerializeField] private Image cortina;
    [SerializeField] private AudioClip intro, loop, ending, complet;
    [SerializeField] private AudioSource fuente;

    // Start is called before the first frame update
    void Awake()
    {
        if(FindObjectsOfType<InstalerServiceLocator>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        var nube = new ServicioDePlayFabnube(titlId);
        ServiceLocator.Instance.RegisterService<IServicioDeGuardado>(nube);

        var sistemaDeGuardadoLocal = new GuardadoLocalDeDatos();
        var logica = new LogicaDeCalculosDePuncuacion(sistemaDeGuardadoLocal);
        ServiceLocator.Instance.RegisterService<ILogicaDeCalculoDePuntuaciones>(logica);

        var transiciones = new TransicionEscena(cortina);
        ServiceLocator.Instance.RegisterService<ITransicionEscenaMono>(transiciones);

        var manejadorMusica = new ManejadorDeMusica(intro, loop, ending, complet, fuente);
        ServiceLocator.Instance.RegisterService<IManejadorDeMusica>(manejadorMusica);

        DontDestroyOnLoad(gameObject);
    }

}