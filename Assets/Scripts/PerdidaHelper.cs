using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PerdidaHelper : MonoBehaviour
{
    public string EscenaPortada;
    public Text PuntajeTotal;
    public InputField inicialesJugador;

    public int[] puntajes;
    public string[] puntajesNombres;

    private int pivote;
    private int temp;
    private string pivotenombre;
    private string tempNombre;

    public void GuardarDatosDiscoDuro()
    {
        puntajes = new int[3];
        puntajesNombres = new string[3];

        RecuperarDatos();

        pivote = GameManager.instancia.ObtenerPuntaje();

        if (pivote > puntajes[0])
        {
            tempNombre = puntajesNombres[1];
            temp = puntajes[1];

            puntajesNombres[1] = puntajesNombres[0];
            puntajes[1] = puntajes[0];

            puntajesNombres[0] = pivotenombre;
            puntajes[0] = pivote;
       

            pivotenombre = tempNombre;
            pivote = temp;
        }
        if (pivote > puntajes[1])
        {
            tempNombre = puntajesNombres[2];
            temp = puntajes[2];

            puntajesNombres[2] = puntajesNombres[1];
            puntajes[2] = puntajes[1];

            puntajesNombres[1] = pivotenombre;
            puntajes[1] = pivote;

            pivotenombre = tempNombre;
            pivote = temp;
        }
        if (pivote > puntajes[2])
        {
            puntajesNombres[2] = pivotenombre;
            puntajes[2] = pivote;
        }

        GuardarDatos();
    }

    private void Start()
    {
        PuntajeTotal.text = GameManager.instancia.ObtenerPuntaje().ToString();    
    }

    private void RecuperarDatos()
    {
        puntajes[0] = PlayerPrefs.GetInt("Pos01", 0);
        puntajes[1] = PlayerPrefs.GetInt("Pos02", 0);
        puntajes[2] = PlayerPrefs.GetInt("Pos03", 0);

        puntajesNombres[0] = PlayerPrefs.GetString("PosNombre01", "UCR");
        puntajesNombres[1] = PlayerPrefs.GetString("PosNombre02", "UCR");
        puntajesNombres[2] = PlayerPrefs.GetString("PosNombre03", "UCR");

    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetInt("Pos1", puntajes[0]);
        PlayerPrefs.SetInt("Pos2", puntajes[1]);
        PlayerPrefs.SetInt("Pos3", puntajes[2]);

        PlayerPrefs.SetString("PosNombre01", puntajesNombres[0]);
        PlayerPrefs.SetString("PosNombre02", puntajesNombres[1]);
        PlayerPrefs.SetString("PosNombre03", puntajesNombres[2]);
    }

    public void VolverPortada()
    {
       pivotenombre= inicialesJugador.text;
        GuardarDatosDiscoDuro();

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
