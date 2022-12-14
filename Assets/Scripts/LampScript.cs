using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer lampMeshRenderer;
    [SerializeField] private GameObject lamp;
   public void turnOn()
    {
        lamp.SetActive(true);
        lampMeshRenderer.materials[3].SetColor("_EmissionColor", Color.white);
    }
    public void turnOff()
    {
        lamp.SetActive(false);
        lampMeshRenderer.materials[3].SetColor("_EmissionColor", Color.black);
    }
}
