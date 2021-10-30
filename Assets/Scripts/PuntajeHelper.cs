using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuntajeHelper : MonoBehaviour
{



    public string EscenaPortada;
    public float timer= 5f;
    public Text PrimerLugarPuntaje;
    public Text PrimerLugarNombre;

    public Text SegundoLugarPuntaje;
    public Text SegundoLugarNombre;

    public Text TercerLugarPuntaje;
    public Text TercerrLugarNombre;
    // Start is called before the first frame update
    void Start()
    {

        PrimerLugarPuntaje.text = PlayerPrefs.GetInt("Pos01", 0).ToString();
        PrimerLugarNombre.text =  PlayerPrefs.GetString("PosNombre01", "UCR");

        SegundoLugarPuntaje.text = PlayerPrefs.GetInt("Pos02", 0).ToString();
        SegundoLugarNombre.text =  PlayerPrefs.GetString("PosNombre02", "UCR");

        TercerLugarPuntaje.text = PlayerPrefs.GetInt("Pos03", 0).ToString();
        TercerrLugarNombre.text = PlayerPrefs.GetString("PosNombre03", "UCR");

        StartCoroutine(EsperarCambioEscena());
    }


    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);

        VolverPortada();
    }
    public void VolverPortada()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPortada);
        }
        catch
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }

}
