using System.Collections;
using IslandGame.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityServiceLocator;

namespace IslandGame.SceneControllers
{
    public class IntroSceneController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string mainMenuSceneName = "SCN_MainMenu";
        [SerializeField] private string islandSceneName = "SCN_Island";
        [SerializeField] private float loadingDelay = 1.0f;
        
        private TransitionService _transitionService;
        
        void Start()
        {
            _transitionService = ServiceLocator.Global.Get<TransitionService>();
            StartCoroutine(LoadScenesWithTransition());
        }

        private IEnumerator LoadScenesWithTransition()
        {
            _transitionService.FadeOut();
            var currentScene = SceneManager.GetActiveScene();
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(mainMenuSceneName, LoadSceneMode.Additive);
            while (loadingScene is { isDone: false })
            {
                yield return null;
            }
            AsyncOperation mainMenuScene = SceneManager.LoadSceneAsync(islandSceneName, LoadSceneMode.Additive);
            while (mainMenuScene is { isDone: false })
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(islandSceneName));
            yield return new WaitForSeconds(loadingDelay);
            _transitionService.FadeIn();
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
