using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private Renderer window1,window2;
    [SerializeField] Material[] emissiveMaterial, emissiveMaterial2;
    private float intensity;
    private Color windowColor = new Color(70f, 119f, 191f);
    private void Start()
    {
        emissiveMaterial = window1.GetComponent<Renderer>().materials;
        emissiveMaterial2 = window2.GetComponent<Renderer>().materials;
    }
    void Update()
    {
        ChangeEmission();
    }

    private void TurnEmissionOff()
    {
        emissiveMaterial[1].DisableKeyword("WindowLight");
    }


    private void ChangeEmission()
    {
        
        switch(timeManager.hours)
        {
            case 7: intensity = 0f; SetEmission();
                break;
            case 8: intensity = 5f; SetEmission();
                break;
            case 9: intensity = 0.7f; SetEmission();
                break;
            case 10: intensity = 0.9f; SetEmission();
                break; 
            case 11: intensity = 1.0f; SetEmission();
                break;
            case 12: intensity = 1.2f; SetEmission();
                break;
            case 13: intensity = 1.0f; SetEmission();
                break;
            case 14: intensity = 0.9f; SetEmission();
                break;
            case 15: intensity = 0.8f; SetEmission();
                break;
            case 16: intensity = 0.7f; SetEmission();
                break;
            case 17: intensity = 0.6f; SetEmission();
                break;
            case 18: intensity = 0.5f; SetEmission();
                break;
            case 19: intensity = 0.4f; SetEmission();
                break;
            case 20: intensity = 0.2f; SetEmission();
                break;
            case 21: intensity = 0.0f; SetEmission();
                break;
        }

    }
    private void SetEmission()
    {
        emissiveMaterial[1].SetColor("_EmissionColor", windowColor * intensity);
        emissiveMaterial2[1].SetColor("_EmissionColor", windowColor * intensity);
    }
}
