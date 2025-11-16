using CoreScripts;
using UnityEngine;
using UnityEngine.InputSystem;

    public enum FPS
    {
        FPS30,FPS60,FPS90,FPS120
    }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    [Header("FPS")]
    public FPS fps = FPS.FPS60;

    [Header("Cursor Lock State")]
    public bool cursorLock;

    public bool inGame = false;
    public bool inMainMenu;
    void Awake()
    {
        if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        SetFPS(fps);
    }
    void Update()
    {

    }

    public void SetFPS(FPS fps)
    {
        switch (fps)
        {
            case FPS.FPS30:
                Application.targetFrameRate = 30;
                break;
            case FPS.FPS60:
                Application.targetFrameRate = 60;
                break;
            case FPS.FPS90:
                Application.targetFrameRate = 90;
                break;
            case FPS.FPS120:
                Application.targetFrameRate = 120;
                break;
        }
    }

    public CursorLockMode CursorLockState(bool lockstate)
    {
        cursorLock = lockstate;
        Debug.Log("Cursor Lock State: " + cursorLock);
        return Cursor.lockState = lockstate ? CursorLockMode.Locked : CursorLockMode.None;

    }
  
}
