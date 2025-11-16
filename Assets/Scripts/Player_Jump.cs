using CoreScripts;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerMovement))]
public class Player_Jump : MonoBehaviour
{
    PlayerMovement playerMovement;

    public float jumpForce;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        Player_Input.Instance.OnJump += Jump;
    }

    void OnDestroy()
    {
        Player_Input.Instance.OnJump -= Jump;
        
    }
    
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!playerMovement.isGrounded) return;
        playerMovement.charVelocity.y = jumpForce;
        Debug.Log("OnJump event");

    }
}
