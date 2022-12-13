using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairLook : MonoBehaviour
{
    public Camera chairCam;
    public float xRotation = 0f;
    public float yRotation = 0f;

    float ySensivity = 30f;
    float xSensivity = 30f;




    public void ProcessLookChair(Vector2 input)
    {
        float mousex=input.x;
        float mousey=input.y;
        xRotation -= (mousey * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -25f, 40f);
        //chairCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        yRotation += (mousex * Time.deltaTime) * xSensivity;
        yRotation = Mathf.Clamp(yRotation, 120f, 240f);
        chairCam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}

