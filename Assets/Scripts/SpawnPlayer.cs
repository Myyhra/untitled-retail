using System.Collections;
using CoreScripts;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject PlayerObject;
    void Awake()
    {
    }

    void Start()
    {
        StartCoroutine(DelayGet());

    }
    void Update()
    {

    }
    
    IEnumerator DelayGet()
    {
        yield return GameSceneManager.WaitForSceneLoaded("Player");
        yield return null;
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerObject.transform.position = spawnLocation.position;


    }
}
