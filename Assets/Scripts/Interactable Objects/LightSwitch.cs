using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch :Interactable
{
    [SerializeField] private Animator lsAnimator;
    [SerializeField] private GameObject Lamp;
    protected override void Interact()
    {
        lsAnimator.SetTrigger("Pressed");
    }
   
}
