using UnityEngine;
using IslandGame.Utils;

namespace IslandGame.Services
{
    public class TransitionService : BaseService
    {
        [Header("References")]
        [SerializeField] private GameObject canvas;
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Settings")]
        [SerializeField] private float fadeOutTime = 0.5f;
        [SerializeField] private float fadeInTime = 0.5f;
        
        private Coroutine _fadeOutCoroutine;
        
        public override void Initialize()
        {
            MyUtils.SetCanvasGroupEnabled(canvasGroup, false);
            canvasGroup.alpha = 0;
            base.Initialize();
        }

        public void FadeOut()
        {
            MyUtils.SetCanvasGroupEnabled(canvasGroup, true);
            canvasGroup.alpha = 1;
        }

        public void FadeIn()
        {
            MyUtils.SetCanvasGroupEnabled(canvasGroup, false);
            canvasGroup.alpha = 0;
        }
    }
}