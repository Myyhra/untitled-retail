using System.Collections;
using CoreScripts;
using UnityEngine;

public class billboarding : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    void OnEnable()
    {
        StartCoroutine(WaitForCamera());
    }
    void Update()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    IEnumerator WaitForCamera()
    {
        yield return GameSceneManager.WaitForSceneLoaded("Player");
        mainCamera = Camera.main;

    }
}
