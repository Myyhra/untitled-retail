using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void NewGameStart()
    {
        SceneManager.LoadScene("Level");
    }
}
