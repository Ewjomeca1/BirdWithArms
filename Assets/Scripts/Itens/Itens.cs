using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Itens : MonoBehaviour
{
    
    public Personagem player;
    public AudioSource som;
    public AudioClip barulho;

    [SerializeField] ScriptableCharacter scriptable;

    
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Funciona a colisao, so colocar os efeitos dos buffs e pontos aqui.
            som.PlayOneShot(barulho);
            Debug.Log("ddd");
            if(scriptable.buffDobro)
            {
                scriptable.score ++;
            }
            scriptable.score++;
            HUD.controller.UpdateHUD();

            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        Destroy(this.gameObject , 10);
    }


    
}
