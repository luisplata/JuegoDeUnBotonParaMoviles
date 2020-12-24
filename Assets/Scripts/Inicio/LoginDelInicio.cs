using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginDelInicio : MonoBehaviour
{
    [SerializeField] private Button botonOpciones;
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarMusicaCompleta();
        botonOpciones.onClick.AddListener(() => { BotonDeOpciones(); });
    }

    public void BotonDeOpciones()
    {
        ServiceLocator.Instance.GetService<IManejadorDeOpcionesDeMenu>().UtilizarMenuDeOpciones();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ServiceLocator.Instance.GetService<IManejadorDeMusica>().QuitarMusica();
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(-1);
        }
    }
}
