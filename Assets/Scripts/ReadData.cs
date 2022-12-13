using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;

public class ReadData : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    TalkingStates talkingStates;
    Image typePhoto;
    public Action<int> sendType;
    TextMeshProUGUI argumentText;
    [HideInInspector]
    public int type;
    public Answer answer;
    void Start()
    {
        talkingStates=GameObject.Find("TalkingScreen").GetComponent<TalkingStates>();
        argumentText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        typePhoto = transform.GetChild(1).GetComponent<Image>();
        argumentText.text = answer.argument;
        typePhoto.sprite = answer.artwork;
        type = answer.type; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (type)
        {
            case 1: argumentText.color = new Color32(255, 205, 56,255);
                break;
            case 2:
                argumentText.color = new Color32(117, 255, 58,255);
                break;
            case 3:
                argumentText.color =  new Color32(101, 147, 244,255);
                break;
            case 4:
                argumentText.color = new Color32(199, 86, 77,255);
                break;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        argumentText.color = Color.white;
    }
    public void OnButtonPressed()
    {
        sendType.Invoke(type);
    }
    public void SetTimerTo1()
    {
        talkingStates.SetTimerTo1();
    }
   

  
}
