using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortadaHelper : MonoBehaviour
{
    public string EscenaJuego;
    public string EscenaPuntaje;

    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }


    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);

        VerMejoresPunatajes();
    }

    public void IniciarJuego()
    {

        try
        {
            GameManager.instancia.CambiarEscena(EscenaJuego);
        }
        catch(System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
      
    }

    public void VerMejoresPunatajes()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPuntaje);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }

    public void Salir()
    {
        try
        {
            GameManager.instancia.Salir();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }
}
