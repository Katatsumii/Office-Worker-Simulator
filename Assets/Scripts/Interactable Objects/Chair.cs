using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
   [SerializeField] private GameObject sitCamera;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MeshRenderer playerMesh;
    [SerializeField] private MeshRenderer chairMesh;
    private Transform chairTransform;
    public bool isSiting = false;
    private void Start()
    {
        chairTransform = transform;
    }
    protected override void Interact()
    {
        sitCamera.SetActive(true);
        playerCamera.SetActive(false);
        isSiting = true;
        playerMesh.enabled = false;

        chairTransform.rotation = Quaternion.Euler(0, 90, 0);

        
    }
    public void GetUp()
    {
        if(isSiting==true)
        {
            sitCamera.SetActive(false);
            playerCamera.SetActive(true);
            isSiting=false;
            playerMesh.enabled = true;
            chairTransform.rotation = Quaternion.Euler(0, 20, 0);

        }
    }
}
