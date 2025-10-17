using System.Collections;
using TMPro;
using UnityEngine;

namespace IslandGame.UI
{
    public class LoadingSceneController : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private TMP_Text loadingLabel;

        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Animation Settings")] [SerializeField]
        private string loadingLabelPrefix = "Loading ";

        [SerializeField] private float animationInterval = 0.33f;

        private Coroutine animationCoroutine;

        void OnEnable()
        {
            animationCoroutine = StartCoroutine(AnimateLoadingLabelCoroutine());
        }

        void OnDisable()
        {
            if (animationCoroutine != null)
                StopCoroutine(animationCoroutine);
        }

        private IEnumerator AnimateLoadingLabelCoroutine()
        {
            while (true)
            {
                loadingLabel.text = loadingLabelPrefix + ".";
                yield return new WaitForSeconds(animationInterval);
                loadingLabel.text = loadingLabelPrefix + "..";
                yield return new WaitForSeconds(animationInterval);
                loadingLabel.text = loadingLabelPrefix + "...";
                yield return new WaitForSeconds(animationInterval);
            }
        }
    }
}
