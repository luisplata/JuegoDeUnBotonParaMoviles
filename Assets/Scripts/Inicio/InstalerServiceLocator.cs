using UnityEngine;

public class InstalerServiceLocator : MonoBehaviour
{
    [SerializeField] private string titlId;

    // Start is called before the first frame update
    void Awake()
    {
        IServicioDeGuardado nube = new ServicioDePlayFabnube(titlId);
        ServiceLocator.Instance.RegisterService(nube);

        IGuardadoLocalDeDatos sistemaDeGuardadoLocal = new GuardadoLocalDeDatos();
        ILogicaDeCalculoDePuntuaciones logica = new LogicaDeCalculosDePuncuacion(sistemaDeGuardadoLocal);
        ServiceLocator.Instance.RegisterService(logica);

        DontDestroyOnLoad(gameObject);
    }

}