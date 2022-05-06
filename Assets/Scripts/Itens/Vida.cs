using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] ScriptableCharacter scriptable;

    public AudioClip clip;
    public AudioSource som;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(scriptable.vidas <3)
            {
                som.PlayOneShot(clip);
                scriptable.vidas ++;
                HUD.controller.UpdateHUD();
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            
        }
    }
    void FixedUpdate()
    {
        Destroy(this.gameObject , 10);
    }
    

}
