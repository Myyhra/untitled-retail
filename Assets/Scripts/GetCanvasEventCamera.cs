using System.Collections;
using CoreScripts;
using UnityEngine;

public class GetCanvasEventCamera : MonoBehaviour
{
    [SerializeField] private Camera worldCanvasCamera;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    void OnEnable()
    {
        StartCoroutine(GetEventCamera());
    }

    
    void Update()
    {
        
    }

    IEnumerator GetEventCamera()
    {
        yield return GameSceneManager.WaitForSceneLoaded("Player");

        worldCanvasCamera = Camera.main;

        yield return null;

        canvas.worldCamera = worldCanvasCamera;
    }
}
