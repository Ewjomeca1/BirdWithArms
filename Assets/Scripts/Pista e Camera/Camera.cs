using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo;
    void Start()
    {
        
    }

    void Follow()
    {
        Vector3 pos;

        pos = new Vector3(alvo.transform.position.x , this.transform.position.y, alvo.position.z -8);

        this.transform.position = pos;
    }
    void Update()
    {
        Follow();
    }
}
