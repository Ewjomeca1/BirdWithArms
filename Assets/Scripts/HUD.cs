using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public delegate void delegateAction();
    public delegateAction actionMorre;
    public ScriptableCharacter scriptable;
    [SerializeField]Personagem player;
    public GameObject GameOverUI;
    public static HUD controller;
    [SerializeField] Text pontos;
    [SerializeField] Text vida;

    [SerializeField] Image coracao;
    void Start()
    {
        scriptable.score = 0;
        scriptable.vidas = 3;
        controller = this;
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        pontos.text = " " + scriptable.score;
        coracao.fillAmount = scriptable.vidas * 0.33f;
    }
    void FixedUpdate()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void TentarDnv()
    {
        SceneManager.LoadScene("Fase");
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void maisVida()
    {
        if(scriptable.score >= 5 && scriptable.vidas < 3)
        {
            scriptable.score += -5;
            scriptable.vidas += 1;
            UpdateHUD();

        }
    }
}
