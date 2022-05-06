using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public GameObject conector2;

    private void OnTriggerEnter(Collider other)
    {
        Pista.pista.GeraPista();
        //Destroy(this.transform.parent.gameObject,2);
        Pecas essaPeca = this.transform.GetComponentInParent<Pecas>();
       if (essaPeca.nivel== Pista.pista.cenarioAtual)
        Pista.pista.poolModulosPista.Add(essaPeca);
       
    }


}
