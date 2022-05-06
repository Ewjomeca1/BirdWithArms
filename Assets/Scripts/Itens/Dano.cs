using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dano : MonoBehaviour
{
    [SerializeField] ScriptableCharacter scriptable;
    public Personagem player;
    public AudioSource som;
    public AudioClip damage;

    void Start()
    {
        
        scriptable.buffInvencivel = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
    }
    
    void FixedUpdate()
    {
        Destroy(this.gameObject , 10);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player") && scriptable.buffInvencivel == false)
        {
            player.timer -= Time.deltaTime;
            scriptable.vidas --;
            HUD.controller.UpdateHUD();
            player.timer = player.duration;
            if(scriptable.vidas < 1)
            {
                player.speed = 0;
                player.Morreu();
            }
            Destroy(this.gameObject);
        }
    }
}
