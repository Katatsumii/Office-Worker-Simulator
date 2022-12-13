using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] Chair chair;
    private PlayerInput playerInput;
    [SerializeField]
    private PauseMenuScript pauseMenuScript;
    [SerializeField]
    private UIControls uiControls;
    public PlayerInput.OnFootActions onFoot;
    public PlayerInput.InPauseMenuActions inPauseMenu;
    private PlayerMotor motor;
    private PlayerLook look;
    private ChairLook chairlook;
    
    
    void Awake()
    {
        playerInput=new PlayerInput();
        onFoot = playerInput.OnFoot;
        inPauseMenu = playerInput.InPauseMenu;

        motor=GetComponent<PlayerMotor>();
        look=GetComponent<PlayerLook>();
        chairlook=GetComponent<ChairLook>();
    }
    private void Start()
    {
        onFoot.OpenPauseMenu.performed += ctx=> pauseMenuScript.OpenPauseMenu();
        inPauseMenu.Return.performed +=ctx=> pauseMenuScript.ClosePauseMenu();
        onFoot.OpenStats.performed +=ctx=> uiControls.OpenStatsWindow();
        inPauseMenu.Return.performed += ctx => uiControls.CloseStatsWindow();
        inPauseMenu.CloseStats.performed += ctx => uiControls.CloseStatsWindow();
        onFoot.Getup.performed+= ctx => chair.GetUp();
 
    }
    private void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Walking.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        if(chair.isSiting==false)
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
       else if (chair.isSiting==true)
            chairlook.ProcessLookChair(onFoot.Look.ReadValue<Vector2>());

    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}

