using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{
    public Material materialResaltado;
    public Material materialOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
       
    // Este codigo se activa cuando entra una colision

    Debug.Log("Un objeto a entrado al trigger");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Es un objeto con el tag Player");

            try
            {
                var player = other.GetComponent<Player>();

                player.Alerta();

                var rigifbd = other.GetComponent<Rigidbody>();


                rigifbd.AddForce(new Vector3(
                  Random.Range(-1000f, 1000f),
                  Random.Range(1f, 1000f),
                  Random.Range(-1000f, 1000f)));

            }
            catch (System.Exception ex)
            {
                Debug.Log("Se olvido poner componente Player en el objeto que tiene la etiqueta player"+ ex.Message);
            }

           
        }


    }

    private void OnTriggerStay(Collider other)
    {
        // Este codigo se ejecuta por frame (Como una Update) mientras exista una colision
        Debug.Log("Un objeto esta dentro del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialResaltado;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Este se ejecuta cuando sale del volumen de un trigger 
        Debug.Log("Un objeto a salido del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialOriginal;
        }
    }
}
