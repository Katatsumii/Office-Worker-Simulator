using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingLights : MonoBehaviour
{
    [SerializeField] private GameObject light2;

    public void DisableLight()
    {
        light2.SetActive(false);
    }
    public void EnableLight()
    {
        light2.SetActive(true);
    }
}
