using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoTiempo : Objetivo
{
    public bool reposicionar = true;
    public float tiempo;
    public Material positivo;
    public Material negativo;


    private void Start()
    {
        if (tiempo > 0)
        {
            this.GetComponent<Renderer>().material = positivo;
        }
        else
        {
            this.GetComponent<Renderer>().material = negativo;
        }

    }
    protected override void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // le mando la operacion tiempo

           var player = other.GetComponent<Player>();

            if (tiempo>0)
            {
                player.ModificarTiempo(tiempo);
            }
            else if(!player.inmunidad && tiempo<0)
            {
                player.ModificarTiempo(tiempo);
            }
           
        }

        if (reposicionar)
        {
            base.OnTriggerEnter(other);
        }
    }

    public void ReposicionarNuevo()
    {
        base.Reposicionar();
    }
}
