using UnityEngine;
using UnityEngine.UI;

public class InstalerServiceLocator : MonoBehaviour
{
    [SerializeField] private string titlId;
    [SerializeField] private Image cortina;

    // Start is called before the first frame update
    void Awake()
    {
        if(FindObjectsOfType<InstalerServiceLocator>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        IServicioDeGuardado nube = new ServicioDePlayFabnube(titlId);
        ServiceLocator.Instance.RegisterService(nube);

        IGuardadoLocalDeDatos sistemaDeGuardadoLocal = new GuardadoLocalDeDatos();
        ILogicaDeCalculoDePuntuaciones logica = new LogicaDeCalculosDePuncuacion(sistemaDeGuardadoLocal);
        ServiceLocator.Instance.RegisterService<ILogicaDeCalculoDePuntuaciones>(logica);

        var transiciones = new TransicionEscena(cortina);
        ServiceLocator.Instance.RegisterService<ITransicionEscenaMono>(transiciones);

        DontDestroyOnLoad(gameObject);
    }

}