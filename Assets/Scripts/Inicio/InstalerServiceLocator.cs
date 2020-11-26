using UnityEngine;

public class InstalerServiceLocator : MonoBehaviour
{
    [SerializeField] private string titlId;

    // Start is called before the first frame update
    void Awake()
    {
        IServicioDePlayFabNube nube = new ServicioDePlayFabnube(titlId);
        ServiceLocator.Instance.RegisterService(nube);

        ILogicaDeCalculoDePuntuaciones logica = new LogicaDeCalculosDePuncuacion();
        ServiceLocator.Instance.RegisterService(logica);

        DontDestroyOnLoad(gameObject);
    }

}