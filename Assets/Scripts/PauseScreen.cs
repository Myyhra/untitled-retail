using CoreScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;

    public bool isPaused;
    void Start()
    {
        Player_Input.Instance.OnEscape += ShowPauseScreen;
        
    }

    void OnDestroy()
    {
        Player_Input.Instance.OnEscape -= ShowPauseScreen;
        
    }

    void Update()
    {

    }
    
    public void ShowPauseScreen(InputAction.CallbackContext ctx)
    {
        if (isPaused == false)
        {
            GameManager.Instance.CursorLockState(false);
            PauseCanvas.SetActive(true);
            isPaused = true;
            // Player_Input.Instance.canMove = false;
        }
        else
        {
            GameManager.Instance.CursorLockState(true);
            PauseCanvas.SetActive(false);
            isPaused = false;
            // Player_Input.Instance.canMove = true;
        }
    }
}
