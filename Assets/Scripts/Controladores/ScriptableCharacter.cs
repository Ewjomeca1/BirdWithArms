using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName="Salvar",menuName="Scriptable")]

public class ScriptableCharacter : ScriptableObject
{
    public int vidas = 3;
    public int score = 0;

    public bool buffInvencivel = false;

    public bool buffDobro = false;    

    public bool persona1 = false;
    public bool persona2 = false;
}
