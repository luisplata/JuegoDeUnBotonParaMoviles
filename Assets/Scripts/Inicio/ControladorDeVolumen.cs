using UnityEngine;
using UnityEngine.UI;

public class ControladorDeVolumen : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("volumenGeneral"))
        {
            slider.value = PlayerPrefs.GetFloat("volumenGeneral");
        }
        else
        {
            slider.value = 1;
        }
        audio.volume = slider.value;
        slider.onValueChanged.AddListener(delegate { CambioDeVolumenGeneral(); });
    }
    //por cada audio se va a tener uno de estos
    public void CambioDeVolumenGeneral()
    {
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("volumenGeneral", slider.value);
    }
}