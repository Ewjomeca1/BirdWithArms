using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comecar : MonoBehaviour
{
    public ScriptableCharacter script;
    public void Comeca1()
    {
        script.persona1 = true;
        SceneManager.LoadScene("Fase");
    }
    public void Comeca2()
    {
        script.persona2 = true;
        SceneManager.LoadScene("Fase2");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
