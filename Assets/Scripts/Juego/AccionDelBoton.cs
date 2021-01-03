using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccionDelBoton : MonoBehaviour, IAccionDelBotonMono
{
    [SerializeField] private Button boton, botonDeOpciones;
    [SerializeField] private TextMeshProUGUI textoPuntuacion;
    [SerializeField] private float tiempoQueTieneQueDejarDePrecionarElBoton;
    [SerializeField] private List<MovimientoDeDancer> dancers;
    [SerializeField] private CalculoDeArea area;
    [SerializeField] private GameObject prefabDancer;
    private Boton logicaBoton;
    private float deltaTimeLocal;
    

    public void ActualizarPuntuacion(int puntuacion)
    {
        textoPuntuacion.text = puntuacion.ToString();
    }

    public void InstanciarDancer(Vector2 crearObjectoDentroDelCuadrado)
    {
        dancers.Add(Instantiate(prefabDancer, crearObjectoDentroDelCuadrado, Quaternion.identity).GetComponent<MovimientoDeDancer>());
    }

    public void PonerBailarDancers()
    {
        foreach(IMovimientoDeDancerMono m in dancers)
        {
            m.CambioDeLado();
        }
    }

    public void ReinciarTiempoDeEspera()
    {
        deltaTimeLocal = 0;
    }

    // Start is called before the first frame update
    public void Start()
    {
        logicaBoton = new Boton(this, area);
        boton.onClick.AddListener(() => {
            logicaBoton.AumentandoPuntuacion();
        });
        botonDeOpciones.onClick.AddListener(() => {
            ServiceLocator.Instance.GetService<IManejadorDeOpcionesDeMenu>().UtilizarMenuDeOpciones();
        });
        logicaBoton.YaGuardoData = true;
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarLaMusicaLoopeada();
    }

    private void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        logicaBoton.TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(deltaTimeLocal, tiempoQueTieneQueDejarDePrecionarElBoton);
    }
}