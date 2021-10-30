using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public float minX, maxX;
    public float minZ, maxZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Reposicionar();
            Debug.Log("Colision detectada con player");
        }
    }


    protected void Reposicionar()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }

   
}
