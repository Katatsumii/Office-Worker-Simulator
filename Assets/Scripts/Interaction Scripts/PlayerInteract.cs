using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Camera sitCam;
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private InteractUI interactUI;
    private InputManager inputManager;
    [SerializeField] Chair chair;



    private void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        interactUI = GetComponent<InteractUI>();
        inputManager = GetComponent<InputManager>();
    }
    void Update()
    {
        interactUI.UpdatePrompt(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Ray ray2= new Ray(sitCam.transform.position, sitCam.transform.forward);
        RaycastHit hitInfo;

        if(chair.isSiting==false)
        {
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {

                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                interactUI.UpdatePrompt(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }


            }
        }

        }
        else if (chair.isSiting==true)
        {
            if (Physics.Raycast(ray2, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {

                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    interactUI.UpdatePrompt(interactable.promptMessage);
                    if (inputManager.onFoot.Interact.triggered)
                    {
                        interactable.BaseInteract();
                    }


                }
            }

        }

    }
}
