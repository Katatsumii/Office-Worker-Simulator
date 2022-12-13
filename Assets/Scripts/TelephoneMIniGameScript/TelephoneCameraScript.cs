using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneCameraScript : MonoBehaviour
{
    Animator anim;
    public GameObject canvas1;
    public GameObject cameraPlayer;
    public GameObject sitingCamera;
    [SerializeField] Chair chair;
    
    private void Start()
    {
        anim= GetComponent<Animator>();
        Cursor.visible = true;
    }
   public void animationPlay()
    {
        anim.SetTrigger("PickUp");
    }
    public void rejectCall()
    {

        this.gameObject.SetActive(false);
        canvas1.SetActive(true);
        if(chair.isSiting==false)
            cameraPlayer.SetActive(true);
        else if(chair.isSiting==true)
            sitingCamera.SetActive(true);

    }
    public void ResetAnimator()
    {
        cameraPlayer.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void TalkEnd()
    {
        gameObject.transform.position = new Vector3(-46.97f, 1.668f, 4.409f);
        gameObject.transform.eulerAngles = new Vector3(75.87f, 163.328f, 2.427f);
        canvas1.SetActive(true);
        if (chair.isSiting == false)
        cameraPlayer.SetActive(true);
        else if (chair.isSiting == true)
        sitingCamera.SetActive(true);

        gameObject.SetActive(false);
    }
     
}
