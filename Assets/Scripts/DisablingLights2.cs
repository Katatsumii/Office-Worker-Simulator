using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingLights2 : MonoBehaviour
{
    [SerializeField] private GameObject light1;

    public void DisableLight1()
    {
        light1.SetActive(false);
    }
    public void EnableLight1()
    {
        light1.SetActive(true);
    }
}
