using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientTextScript : MonoBehaviour
{
    public int type;
    [SerializeField]
    private ClientArgumentScripts[] script;
    private ClientArgumentScripts randomscript;

    public TextMeshProUGUI text;
    void Start()
    {
        randomscript = script[Random.Range(0, script.Length)];
        type = randomscript.type;
        text.text = randomscript.text;
    }

}
