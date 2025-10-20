using UnityEngine;

namespace IslandGame.Utils
{
    public static class MyUtils
    {
        public static void SetCanvasGroupEnabled(CanvasGroup canvas, bool enabled)
        {
            canvas.interactable = enabled;
            canvas.blocksRaycasts = enabled;
        }
    }
}