using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : Interactable
{
    [SerializeField] Animator shutterAnimator;
    protected override void Interact()
    {

        shutterAnimator.SetTrigger("Shutter");
    }
}
