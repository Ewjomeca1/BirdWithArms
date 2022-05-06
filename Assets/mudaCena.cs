using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mudaCena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("mudar",3);
    }

    // Update is called once per frame
    void mudar()
    {
        SceneManager.LoadScene("Menu");
    }
}
