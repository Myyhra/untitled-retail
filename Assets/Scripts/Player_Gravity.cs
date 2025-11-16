using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class Player_Gravity : MonoBehaviour
{
    PlayerMovement playerMovement;
    CharacterController characterController;
    public float gravity = 9.14f;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {

    }

    void Update()
    {
        PlayerGravity(gravity);
    }
    public void PlayerGravity(float gravity)
    {
        playerMovement.isGrounded = characterController.isGrounded;
            
            if (playerMovement.isGrounded && playerMovement.charVelocity.y < 0)
            {
                playerMovement.charVelocity.y = 0;

            }
            playerMovement.charVelocity.y -= gravity * Time.deltaTime;
    }
}
