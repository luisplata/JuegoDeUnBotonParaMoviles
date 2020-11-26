using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;

public class AccionDelBoton : MonoBehaviour, IAccionDelBotonMono
{
    [SerializeField] private Button boton;
    [SerializeField] private TextMeshProUGUI textoPuntuacion;
    private Boton logicaBoton;
    private float deltaTimeLocal;
    [SerializeField] private float tiempoQueTieneQueDejarDePrecionarElBoton;

    public bool YaGuardoData { get; set; }

    public void ActualizarPuntuacion(int puntuacion)
    {
        textoPuntuacion.text = puntuacion.ToString();
    }

    public void ReinciarTiempoDeEspera()
    {
        deltaTimeLocal = 0;
        YaGuardoData = false;
    }

    // Start is called before the first frame update
    async void Start()
    {
        logicaBoton = new Boton(this);
        boton.onClick.AddListener(() => { logicaBoton.AumentandoPuntuacion(); });
        YaGuardoData = true;
    }

    private void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        logicaBoton.TerminoElTiempoDeEsperaParaQueGuardeEnLaNube(deltaTimeLocal, tiempoQueTieneQueDejarDePrecionarElBoton, YaGuardoData);
    }
}