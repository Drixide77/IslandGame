using DG.Tweening;
using UnityEngine;

namespace IslandGame.Services
{
    public class AppControlService : BaseService
    {
        private readonly int targetFramerate = 60;
        
        public override void Initialize()
        {
            // Setting target framerate
            Application.targetFrameRate = targetFramerate;
            // Initializing DOTween
            DOTween.Init();
            base.Initialize();
        }

        public void ExitApplication()
        {
            Debug.Log("Exiting game...");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}