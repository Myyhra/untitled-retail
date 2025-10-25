using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Options;
    [SerializeField] GameObject Pause_Main;
    [SerializeField] private bool optionsEnabled;
    // [SerializeField] private bool resumeEnabled;
    // [SerializeField] private bool pause_MainEnabled;
    private int clickDelay = 1;


    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }

    public void ShowOptions()
    {
        if (Options != null)

            if (optionsEnabled == false)
            {
                Options.SetActive(true);
                optionsEnabled = true;
                Pause_Main.SetActive(false);
            }
            else
            {
                Options.SetActive(false);
                optionsEnabled = false;
                Pause_Main.SetActive(true);
            }
        StartCoroutine(ClickDelay(clickDelay));
    }
    public void BackToPauseMenu()
    {
        Pause_Main.SetActive(true);
        Options.SetActive(false);
        optionsEnabled = false;
        StartCoroutine(ClickDelay(clickDelay));
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
    }
    
    IEnumerator ClickDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
