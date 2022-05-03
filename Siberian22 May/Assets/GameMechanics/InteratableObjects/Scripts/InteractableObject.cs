using UnityEngine;
using UnityEngine.Events;
using InventorySystem;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public UnityEvent Interacted;
        [SerializeField]
        private ToolType _requiredTool;

        public ToolType RequiredTool => _requiredTool;

        public abstract void Interact();
    }
}