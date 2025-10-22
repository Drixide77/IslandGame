using IslandGame.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityServiceLocator;

namespace IslandGame.SceneControllers
{
    public class MainMenuSceneController : MonoBehaviour
    {
        [Header("Sgit acene References")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        
        private void Start()
        {
            startButton.onClick.AddListener(OnStartGameButtonPressed);
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(OnStartGameButtonPressed);
            exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
        
        private void OnStartGameButtonPressed()
        {
            // TODO: move all scene loading to service
            SceneManager.UnloadSceneAsync("SCN_MainMenu");
        }

        private void OnExitButtonPressed()
        {
            ServiceLocator.Global.Get<AppControlService>().ExitApplication();
        }
    }
}