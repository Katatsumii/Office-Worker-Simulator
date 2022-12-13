using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ClientData : MonoBehaviour
{
    public ClientScriptableObject[] client;
    public ClientScriptableObject clientCalling;
    public TextMeshProUGUI nameClient;
    public TextMeshProUGUI numberClient;
    public Image typeMain;
    public Image typeSec1;
    public Image typeSec2;
    public int type;
    public int type2;
    public int type3;

    private void OnEnable()
    {
        clientCalling = client[UnityEngine.Random.Range(0, 9)];
        nameClient.text=clientCalling.clientName;
        numberClient.text = clientCalling.number;
        typeMain.sprite = clientCalling.mainTypeS;
        typeSec1.sprite = clientCalling.secondaryType1S;
        typeSec2.sprite = clientCalling.secondaryType2S;
        type = clientCalling.mainType;
        type2 = clientCalling.secondaryType1;
        type3 = clientCalling.secondaryType2;
        if(clientCalling.mainTypeS==null)
             typeMain.enabled = false;
        else
             typeMain.enabled = true;
        if (clientCalling.secondaryType1S == null)
            typeSec1.enabled = false;
        else
            typeSec1.enabled = true;
        if(clientCalling.secondaryType2S == null)
            typeSec2.enabled = false;
        else
            typeSec2.enabled = true;
           
        

        int index=Array.IndexOf(client, clientCalling);


    }
        public void SwapIndex()
    {
        int index = Array.IndexOf(client, clientCalling);
        if (client[index].swaped == false)
        {
        client[index].swaped = true;
        client[index + 10].swaped = true;
        var temporary = client[index];
        client[index] = client[index + 10];
        client[index + 10] = temporary;
       
        }
        else
        {
            return;
        }

    }
}
