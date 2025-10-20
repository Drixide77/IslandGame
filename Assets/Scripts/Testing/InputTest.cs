using IslandGame.Services;
using UnityEngine;
using UnityServiceLocator;

namespace IslandGame.Testing
{
    public class InputTest : MonoBehaviour, IClickable2D
    {
        [SerializeField] private bool exitOnInteract;
        
        private SpriteRenderer _spriteRenderer;
        private AppControlService _appControlService;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _appControlService = ServiceLocator.Global.Get<AppControlService>();
        }

        public void OnClicked()
        {
            _spriteRenderer.color = _spriteRenderer.color == Color.green ? Color.red : Color.green;
            if (exitOnInteract) _appControlService.ExitApplication();
        }
    }
}
