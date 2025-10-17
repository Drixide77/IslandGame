using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IslandGame.SceneControllers
{
    public class IntroSceneController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string loadingSceneName = "SCN_Loading";
        [SerializeField] private string sceneToLoadName = "SCN_MainMenu";
        
        void Start()
        {
            StartCoroutine(LoadSceneWithLoadingScreen());
        }

        private IEnumerator LoadSceneWithLoadingScreen()
        {
            var currentScene = SceneManager.GetActiveScene();
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(loadingSceneName, LoadSceneMode.Additive);
            while (loadingScene is { isDone: false })
            {
                yield return null;
            }
            AsyncOperation mainMenuScene = SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);
            while (mainMenuScene is { isDone: false })
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoadName));
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
