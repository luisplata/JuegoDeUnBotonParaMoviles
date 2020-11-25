using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDeBotones : MonoBehaviour
{
    [SerializeField] private Button boton;
    [SerializeField] private int escenaCargar;
    // Start is called before the first frame update
    void Start()
    {
        boton.onClick.AddListener(delegate { CargarEscena(escenaCargar); });
    }
    public void CargarEscena(int escenaIndex)
    {
        SceneManager.LoadScene(escenaIndex);
    }
}
