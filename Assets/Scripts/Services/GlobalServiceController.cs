using UnityEngine;
using UnityServiceLocator;

namespace IslandGame.Services
{
    public class GlobalServiceController: MonoBehaviour
    {
        [Header("Service References")]
        [SerializeField] private AppControlService appControlService;
        
        private void Awake()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            ServiceLocator.Global.Register<AppControlService>(appControlService);
        }
    }
}