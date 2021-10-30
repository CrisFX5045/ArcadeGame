using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoBoost : Objetivo
{

    public float velocidad;
    public bool reposicionar = true;
    public GameObject prefabBoost;
    private int puntaje;
    private bool dobleBoost = true;
    public float tiempoDeBoost;
    public Material boostEat;
    public Material boostVelocidad;
    public bool inmunidad;
    private void Start()
    {
        this.GetComponent<Renderer>().material = boostVelocidad;
    }
    protected override void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // le mando la operacion tiempo

            var player = other.GetComponent<Player>();
            puntaje = player.ObtenerPuntaje();
            player.AumentarVelocidad(velocidad, tiempoDeBoost);

            if (inmunidad)
            {
                player.ActivarInmunidad(inmunidad);
            }
           
           
        }
        if (reposicionar)
        {
            if (puntaje >= 10 && dobleBoost && prefabBoost !=null)
            {

                GameObject.Instantiate(prefabBoost);
                var objetivoBoost= prefabBoost.GetComponent<ObjetivoBoost>();

                objetivoBoost.GetComponent<Renderer>().material = boostEat;


                objetivoBoost.ReposicionarNuevo();
                Debug.Log("Pone dos amarillos en escena");

                dobleBoost = false;
            }

            base.OnTriggerEnter(other);   
        }


    }

    public void ReposicionarNuevo()
    {
        base.Reposicionar();
    }




}
