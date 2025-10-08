using System.Globalization;
using UnityEngine;
using TMPro;

namespace IslandGame.Utils
{
    [RequireComponent(typeof(TMP_Text))]
    // Code taken from https://github.com/prossel/Unity-FPS-counter/blob/master/Scripts/FPSCounter.cs
    public class FPSCounter : MonoBehaviour
    {
        [Header("Settings")]
        public float updateInterval = 0.2f; //How often should the number update
        public string labelPrefix = "FPS: ";

        private TMP_Text _txt;
        private float _time = 0.0f;
        private int _frames = 0;

        private void Start()
        {
            _txt = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        private void Update()
        {
            _time += Time.unscaledDeltaTime;
            ++_frames;

            // Interval ended - update GUI text and start new interval
            if (!(_time >= updateInterval)) return;
            float fps = (int)(_frames / _time);
            _time = 0.0f;
            _frames = 0;
            
            _txt.text = labelPrefix + fps.ToString(CultureInfo.InvariantCulture);
        }
    }
}