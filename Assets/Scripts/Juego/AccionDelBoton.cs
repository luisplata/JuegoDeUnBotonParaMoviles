using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccionDelBoton : MonoBehaviour, IAccionDelBotonMono
{
    [SerializeField] private Button boton, botonDeOpciones;
    [SerializeField] private TextMeshProUGUI textoPuntuacion;
    [SerializeField] private float tiempoQueTieneQueDejarDePrecionarElBoton;
    [SerializeField] private Sprite caramellDancenLeft, caramellDancenRight, caramellDancenCenter;
    [SerializeField] private SpriteRenderer dancer;
    private Boton logicaBoton;
    private float deltaTimeLocal;
    

    public void ActualizarPuntuacion(int puntuacion)
    {
        textoPuntuacion.text = puntuacion.ToString();
    }

    public void BailandoCenter()
    {
        dancer.sprite = caramellDancenCenter;
    }

    public void BailandoLeft()
    {
        dancer.sprite = caramellDancenLeft;
    }

    public void BailandoRight()
    {
        dancer.sprite = caramellDancenRight;
    }

    public void ReinciarTiempoDeEspera()
    {
        deltaTimeLocal = 0;
    }

    // Start is called before the first frame update
    public void Start()
    {
        logicaBoton = new Boton(this);
        boton.onClick.AddListener(() => { logicaBoton.AumentandoPuntuacion(); });
        botonDeOpciones.onClick.AddListener(() => {
            ServiceLocator.Instance.GetService<IManejadorDeOpcionesDeMenu>().UtilizarMenuDeOpciones();
        });
        logicaBoton.YaGuardoData = true;
        BailandoCenter();
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarLaMusicaLoopeada();
    }

    private void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        logicaBoton.TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(deltaTimeLocal, tiempoQueTieneQueDejarDePrecionarElBoton);
    }
}