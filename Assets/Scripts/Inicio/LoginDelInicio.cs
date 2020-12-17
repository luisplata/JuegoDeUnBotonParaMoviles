using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginDelInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<IManejadorDeMusica>().ComenzarMusicaCompleta();
    }
    
}
