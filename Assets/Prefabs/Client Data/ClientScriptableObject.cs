using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",menuName ="Clients")]
public class ClientScriptableObject : ScriptableObject
{
    public string clientName;
    public string number;
    public Sprite mainTypeS;
    public Sprite secondaryType1S;
    public Sprite secondaryType2S;
    public int mainType;
    public int secondaryType1;
    public int secondaryType2;
    public bool swaped;

}
