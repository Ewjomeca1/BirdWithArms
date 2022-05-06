using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencivelBuff : MonoBehaviour
{
    [SerializeField] ScriptableCharacter scriptable;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            scriptable.buffInvencivel = true;
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        Destroy(this.gameObject, 10);
    }
}
