using UnityEngine;

public class PlayerStartup : MonoBehaviour
{
    [SerializeField] private bool cursorLock;
    void Start()
    {
        GameManager.Instance.CursorLockState(cursorLock);
        
    }
    
}
