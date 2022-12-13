using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject nextDay;

    protected override void Interact()
    {
        nextDay.SetActive(true);
    }
}
