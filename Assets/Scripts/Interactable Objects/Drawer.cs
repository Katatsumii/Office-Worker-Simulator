using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

   protected override void Interact()
    {
        anim.SetTrigger("Open");
    }
}
