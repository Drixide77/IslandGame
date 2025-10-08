using UnityEngine;

namespace IslandGame.Testing
{
    public class InputTest : MonoBehaviour, IClickable2D
    {
        private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnClicked()
        {
            _spriteRenderer.color = _spriteRenderer.color == Color.green ? Color.red : Color.green;
        }
    }
}
