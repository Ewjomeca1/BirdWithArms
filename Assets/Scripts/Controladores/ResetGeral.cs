using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGeral : MonoBehaviour
{
    public ScriptableCharacter script;
    void Start()
    {
        script.persona1 = false;
        script.persona2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
