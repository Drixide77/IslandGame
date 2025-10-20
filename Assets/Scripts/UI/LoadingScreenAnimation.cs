using System.Collections;
using TMPro;
using UnityEngine;

namespace IslandGame.UI
{
    public class LoadingScreenAnimation : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text loadingLabel;

        [Header("Animation Settings")]
        [SerializeField] private string loadingLabelPrefix = "Loading ";
        [SerializeField] private float animationInterval = 0.33f;

        private Coroutine _animationCoroutine;

        void OnEnable()
        {
            _animationCoroutine = StartCoroutine(AnimateLoadingLabelCoroutine());
        }

        void OnDisable()
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
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