using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PauseMenuButtonScript : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Animator anim;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("Start");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("End");
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
