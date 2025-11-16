using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CoreScripts
{
    public class GameSceneManager : MonoBehaviour
    {
        public static GameSceneManager Instance;
        

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


        public AsyncOperation LoadSceneAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }

        public static IEnumerator WaitForSceneLoaded(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);

            while(!scene.isLoaded)
            {
                scene = SceneManager.GetSceneByName(sceneName);
                yield return null;
            }
            yield return null;
        }

    }
}