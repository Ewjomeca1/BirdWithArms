using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] Itens;
    public float maxTime;

    float tempo;


    
    void FixedUpdate()
    {
        
        tempo += Time.deltaTime;
        if(tempo > maxTime)
        {
            tempo = 0;
            int sorte = Random.Range(0,5);
            Vector3 pos= new Vector3(transform.position.x , transform.position.y , transform.position.z );
            Instantiate(Itens[sorte] , pos , Itens[sorte].transform.rotation);
        }
        float [] numeros = {-3,0,3};
        int randomLane = Random.Range(0, 3);
        transform.position = new Vector3(numeros[randomLane], transform.position.y, transform.position.z);
    }
    
}
