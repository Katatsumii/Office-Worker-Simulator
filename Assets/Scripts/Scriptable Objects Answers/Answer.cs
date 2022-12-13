using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Answer",menuName ="Answer")]

public class Answer : ScriptableObject
{
    public string argument;
    public Sprite artwork;
    public int type;
}
