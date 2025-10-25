using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShowOption : MonoBehaviour
{
    [SerializeField] GameObject Options;
    [SerializeField] private bool optionsEnabled;
    private int clickDelay = 1;

    public void ShowOptions()
    {
        if (Options != null)

            if (optionsEnabled == false)
            {
                Options.SetActive(true);
                optionsEnabled = true;
            }
            else
            {
                Options.SetActive(false);
                optionsEnabled = false;
            }
        StartCoroutine(ClickDelay(clickDelay));
    }
    
    IEnumerator ClickDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
    }
    
}
