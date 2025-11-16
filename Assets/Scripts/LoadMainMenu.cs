using CoreScripts;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    
    void Start()
    {
        GameSceneManager.Instance.LoadSceneAsync("MainMenu");
    }

    
    void Update()
    {
        
    }
}
