using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Not working for some reason


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private float masterVol;
    private float musicVol;
    private float SFXVol;

    public void MasterVolume(float value)
    {
        audioMixer.SetFloat("master", Mathf.Log10(value) * 20f);
    }
    public void MusicVolume(float value)
    {
        audioMixer.SetFloat("music", Mathf.Log10(value) * 20f);
        Debug.Log("music Volume set to: " + value);

    }
    public void SFXVolume(float value)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(value) * 20f);
        Debug.Log("SFX Volume set to: " + value);
    }
}
