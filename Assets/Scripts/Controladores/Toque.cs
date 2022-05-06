using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toque : MonoBehaviour
{
    public AudioClip toque;
    public AudioSource som;

    public void Clique()
    {
        som.PlayOneShot(toque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
