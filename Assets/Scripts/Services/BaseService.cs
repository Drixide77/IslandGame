using UnityEngine;

namespace IslandGame.Services
{
    public abstract class BaseService : MonoBehaviour
    {
        private bool _initialized = false;

        public virtual void Initialize()
        {
            _initialized = true;
        }

        public bool IsInitialized() {
            return _initialized;
        }
    }
}
