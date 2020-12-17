using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeEscenarioInformacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarMusicaCompleta();
    }
}
