using CoreScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] Transform cameraTransform;
    public float speed;
    public bool isGrounded;
    public Vector3 charVelocity;

    [Header("If during Pause")]
    public bool canMove = true;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
    }

    void Update()
    {
        if(MoveStateOnPause() == true)
        {
            ControllerMove();
        }
        Debug.Log("Grounded?:" + isGrounded);
    }

    public bool MoveStateOnPause()
    {
        return canMove = GameManager.Instance.cursorLock;
    }
    public void ControllerMove()
    {
        Vector3 horizontalVelocity = GetCameraDirectionForMovement() * speed;
        Vector3 totalVelocity = horizontalVelocity + new Vector3(0, charVelocity.y, 0);
        characterController.Move(totalVelocity * Time.deltaTime);
    }
    private Vector3 GetCameraDirectionForMovement()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
        return camRight * Player_Input.Instance.moveInput.move.x + camForward * Player_Input.Instance.moveInput.move.y;
    }
    
}
