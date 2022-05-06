using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Personagem : MonoBehaviour
{
    public float speed;
    public int vida = 3;
    float originalSpeed;
    public float intesity;
    public float duration;
    public float timer;
    public MeshRenderer mesh;

    public AudioSource dano;

    public AudioSource powerup;

    public AudioSource vidasom;

    public AudioSource moeda;

    public AudioSource Duplo;

    public Animator animController;
    
    Collider col;
    public ScriptableCharacter script;
    void Start()
    {
        originalSpeed = speed;
        script.buffInvencivel = false;
        mesh =  GetComponentInChildren<MeshRenderer>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
    }
    public void Morreu()
    {
        animController.SetTrigger("morreu");
        Invoke("Reiniciar", 2);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("dano") && script.buffInvencivel == false)
        {
            dano.Play();
            animController.SetTrigger("dano");
            StartCoroutine(Pisca());
        }
        else if(other.gameObject.CompareTag("buff") && script.buffInvencivel == true)
        {
            powerup.Play();
            StartCoroutine(Contador());
        }
        else if (other.gameObject.CompareTag("moeda"))
        {
            moeda.Play();
        }
        else if(other.gameObject.CompareTag("item"))
        {
            vidasom.Play();
        }
        else if(other.gameObject.CompareTag("duplo"))
        {
            Duplo.Play();
            StartCoroutine(Dobro());
        }

    }
    IEnumerator Pisca()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
        yield return new WaitForSeconds(0.1f);
        mesh.enabled = true;
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
        yield return new WaitForSeconds(0.1f);
        mesh.enabled = true;
    }
    IEnumerator Contador()
    {
        speed = speed * 1.5f;
        script.buffInvencivel = true;
        yield return new WaitForSeconds(10f);
        speed = originalSpeed;
        script.buffInvencivel = false;
    }
    IEnumerator Dobro()
    {
        script.buffDobro = true;
        yield return new WaitForSeconds(5f);
        script.buffDobro = false;
    }
    void Reiniciar()
    {
        HUD.controller.Reiniciar();
    }
}
