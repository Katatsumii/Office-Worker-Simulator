using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    [SerializeField] private Light ligh1;
    [SerializeField] private Light ligh2;
    [SerializeField] private TimeManager timeManager;
 

    private float[] light1values = new float[]{0.0f,0.2f,0.4f,0.6f,0.8f,1f };
    private float[] light2values = new float[]{ 0.0f, 0.05f, 0.10f, 0.15f, 0.20f, 0.25f };

    private void Update()
    {
     
       switch(timeManager.hours)
        {
            case 7: 
                ligh1.intensity = light1values[0]; ligh2.intensity = light2values[0];
                break;
            case 8:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[1]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[1]);
                break;
            case 9:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[2]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[2]);
                break;
            case 10:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[3]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[3]);
                break;
            case 11:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[4]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[4]);
                break;
            case 12:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[5]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[5]);
                break;
            case 13:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[5]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[5]);
                break;
            case 14:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[4]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[4]);
                break;
            case 15:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[3]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[3]);
                break;
            case 16:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[2]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[2]);
                break;
            case 17:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[1]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[1]);
                break;
            case 18:
                ligh1.intensity = changeLighting(ligh1.intensity, light1values[0]); ligh2.intensity = changeLighting(ligh2.intensity, light2values[0]);
                break;
        
        }
    }
    public float changeLighting(float lightintensity,float lightvalue)
    {
        if (lightintensity < lightvalue)
        {
            lightintensity += Time.deltaTime * 0.05f;
            return lightintensity;
        }
        if (lightintensity > lightvalue)
        {
            lightintensity -= Time.deltaTime * 0.05f;
            return lightintensity;
        }
        else
        {
            return lightintensity;
        }
    }

  
}
