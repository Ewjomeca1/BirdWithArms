using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class teste : MonoBehaviour
{
    public int controlador = 0;
    public Sprite[] coracao;
    public Image UIcoracao;
    void Start()
    {
        
    }


    void Update()
    {
        UIcoracao.sprite = coracao[controlador];
    }
}
