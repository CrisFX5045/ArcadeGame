using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Vector3 _posInicial;
    private Rigidbody rigidBody;
    private float velX, velY;
    private float jump;
    private bool enPiso;
    private float tiempoDeJuego;
    private int puntaje;
    public float velocidad;
    public float fuerzaVertical = 2f;
    public float tiemporTranscurrido = 0f;
    public float tiempoLimite = 30;
    public Text txt_TiempoTranscurrido;
    public Text txt_PuntajeActual;
    public Text txt_LimiteActual;
    public Text txt_VelocidadActual;
    public bool inmunidad = false;
    public Text txt_BoostInmunidad;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instancia.RestaurarPuntaje();
      
        rigidBody = this.GetComponent<Rigidbody>();

        _posInicial = new Vector3(transform.position.x,
            transform.position.y,
             transform.position.z
             );
    }

    public void IncrementarPuntaje(int valor)
    {
        puntaje += valor;
        Debug.Log("Puntaje actual" + puntaje.ToString());

        VerificarPuntajeVelocidad();
    }

    public void AumentarVelocidad(float valor, float tiempo)
    {
       
        velocidad += valor;
        Invoke("ReiniciarVelocidad", 3.0f);
    }

    public void ActivarInmunidad(bool inmunidad)
    {
        this.inmunidad = inmunidad;
        Invoke("DesactivarInmunidad", 6.0f);
    }
    public void DesactivarInmunidad()
    {
        this.inmunidad = false;
    }

    public float VerificarPuntajeVelocidad()
    {
        if (puntaje <= 5)
        {
            return velocidad = 5f;
        }

        else if (puntaje > 5 && puntaje < 10)
        {
           return  velocidad = 4f;
            
        }
        else if(puntaje >= 10)
        {
           return velocidad = 3f;
          
        }
        else
        {
            return 0f;
        }
    
    }

    public void ReiniciarVelocidad()
    {
         velocidad = VerificarPuntajeVelocidad();
    }
    public int ObtenerPuntaje()
    {
        return puntaje;
    }
    public void ModificarTiempo(float valor)
    {

        Debug.Log("Tiempo Actual: " + tiempoDeJuego.ToString());

        tiempoDeJuego -= valor;

        Debug.Log("Tiempo con reduccion: " + tiempoDeJuego.ToString());
    }

    

    // Update is called once per frame
    void Update()
    {

       
        //Actulizar Interfaces graficas

        txt_TiempoTranscurrido.text = tiemporTranscurrido.ToString();
        txt_PuntajeActual.text = puntaje.ToString();
        txt_LimiteActual.text = (tiempoLimite - tiempoDeJuego).ToString();
        txt_VelocidadActual.text = velocidad.ToString();

        //Inmunidad
        if (inmunidad)
        {
            txt_BoostInmunidad.text = "Activada";
        }
        else
        {
            txt_BoostInmunidad.text = "Desactivada";
        }
       

        //Contador de Tiempo

        tiemporTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;

        if (tiempoDeJuego > tiempoLimite)
        {
            FinDeJuego();
        }

        velX = Input.GetAxis("Horizontal"); // -1 ...0 ... jostick 0.5...1
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        enPiso = Physics.Raycast(this.transform.position, Vector3.down, 1.02f);


        if (velX != 0 || velY != 0 )
        {
            rigidBody.velocity = new Vector3(velX, 0, velY) * velocidad;
        }

        
        if (enPiso && jump >= 0.3f)
        {
            rigidBody.AddForce(Vector3.up * fuerzaVertical);
        }
       
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter ha sido presionado");
            transform.position = new Vector3(_posInicial.x,
                 _posInicial.y,
                  _posInicial.z);

           rigidBody.velocity=Vector3.zero;
        }

    }


    public void Alerta()
    {
        Debug.Log("Conexion con un trigger establecida");
    }

    public void FinDeJuego()
    {
        Debug.Log("Juego Finalizado");
        GameManager.instancia.SumarPunataje(Convert.ToInt32(puntaje * tiemporTranscurrido * 100)); 
        GameManager.instancia.CambiarEscena("Perdida");
    }
}
