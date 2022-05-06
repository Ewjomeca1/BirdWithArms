using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Duplo : MonoBehaviour
{
    [SerializeField] ScriptableCharacter scriptable;
    public Personagem player;

    void FixedUpdate()
    {
        Destroy(this.gameObject, 10);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            scriptable.buffDobro = true;
            HUD.controller.UpdateHUD();
            Destroy(this.gameObject);
        }
    }
}
