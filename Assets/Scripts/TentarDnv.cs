using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentarDnv : MonoBehaviour
{
    [SerializeField]ScriptableCharacter scriopt;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Clique()
    {
        if(scriopt.persona1 == true)
        {
            SceneManager.LoadScene("Fase");
        }
        else
        {
            SceneManager.LoadScene("Fase2");
        }
        
    }
    public void Sair()
    {
        Application.Quit();
    }
}
