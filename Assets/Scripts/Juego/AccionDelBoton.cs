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
    [SerializeField] private int cadaCuantosPuntos;
    [SerializeField] private CalculoDeArea area;
    [SerializeField] private GameObject prefabDancer;
    private Boton logicaBoton;
    [SerializeField] private DancersSO dancerConfiguration;
    private DancersFactory dancerFactory;
    private DancerSpawner dancerSpawner;
    private int indexFromSpriteOrder = 100;

    public void ActualizarPuntuacion(int puntuacion)
    {
        textoPuntuacion.text = puntuacion.ToString();
    }

    public void InstanciarDancer(Vector2 crearObjectoDentroDelCuadrado)
    {
        var instancia = dancerSpawner.SpawnDancer();
        instancia.gameObject.transform.position = crearObjectoDentroDelCuadrado;
        instancia.gameObject.GetComponent<SpriteRenderer>().sortingOrder = indexFromSpriteOrder;
        indexFromSpriteOrder++;
        dancers.Add(instancia);
    }

    public void PonerBailarDancers()
    {
        foreach(IMovimientoDeDancerMono m in dancers)
        {
            m.CambioDeLado();
        }
    }

    public void QuitarLosDemasDancers()
    {
        foreach (MovimientoDeDancer m in dancers)
        {
            Destroy(m.gameObject);
        }
        dancers.Clear();
    }

    // Start is called before the first frame update
    public void Start()
    {
        logicaBoton = new Boton(this, area)
        {
            TiempoQueTieneQueDejarDePrecionarElBoton = tiempoQueTieneQueDejarDePrecionarElBoton,
            CadaCuantosPuntos = cadaCuantosPuntos
        };
        boton.onClick.AddListener(() => {
            logicaBoton.AumentandoPuntuacion();
        });
        botonDeOpciones.onClick.AddListener(() => {
            ServiceLocator.Instance.GetService<IManejadorDeOpcionesDeMenu>().UtilizarMenuDeOpciones();
        });
        //logicaBoton.YaGuardoData = true;
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarLaMusicaLoopeada();

        dancerFactory = new DancersFactory(Instantiate(dancerConfiguration));
        dancerSpawner = new DancerSpawner(dancerFactory);
    }

    private void Update()
    {
        logicaBoton.TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(Time.deltaTime);
    }
}