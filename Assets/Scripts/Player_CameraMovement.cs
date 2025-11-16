using System.Runtime.CompilerServices;
using CoreScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_CameraMovement : MonoBehaviour
{
    public float sensitivity = 0.1f;
    private Vector2 _eulerAngles;

    public bool canMove = true;
    void Start()
    {
    }

    void Update()
    {
        if(MoveStateOnPause() == true)
        UpdateCamera(Player_Input.Instance.lookInput.lookMove);
    }

    public bool MoveStateOnPause()
    {
        return canMove = GameManager.Instance.cursorLock;
    }

    public Vector2 UpdateCamera(Vector2 mouseDelta)
    {
        _eulerAngles += new Vector2(-mouseDelta.y, mouseDelta.x) * sensitivity;
        return transform.eulerAngles = _eulerAngles;
    }
    
}
