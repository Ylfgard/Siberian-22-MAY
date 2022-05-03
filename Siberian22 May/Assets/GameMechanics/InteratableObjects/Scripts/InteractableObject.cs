using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using FMODUnity;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public UnityEvent Interacted;
        [SerializeField]
        private ToolType _requiredTool;
        [SerializeField]
        private EventReference[] _soundPaths;

        public ToolType RequiredTool => _requiredTool;

        public virtual void Interact()
        {
            foreach(var path in _soundPaths)
                RuntimeManager.PlayOneShot(path);
        }
    }
}