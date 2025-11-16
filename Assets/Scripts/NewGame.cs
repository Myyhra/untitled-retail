using CoreScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public string NewGameScene;
    public void NewGameStart()
    {
        GameSceneManager.Instance.LoadScene(NewGameScene);
    }
}
