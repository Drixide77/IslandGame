using UnityEngine;
using UnityServiceLocator;

namespace IslandGame.Services
{
    [DefaultExecutionOrder(-1000)]
    public class GlobalServiceController : MonoBehaviour
    {
        // Singleton pattern
        public static GlobalServiceController Instance { get; private set; }
        
        [Header("Service References")]
        [SerializeField] private AppControlService appControlService;
        [SerializeField] private TransitionService transitionService;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Initialize()
        {
            RegisterServices();
        }
        
        private void RegisterServices()
        {
            appControlService.Initialize();
            ServiceLocator.Global.Register(appControlService);
            transitionService.Initialize();
            ServiceLocator.Global.Register(transitionService);
        }
    }
}