using UnityEngine;
using InventorySystem;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        private ToolType _requiredTool;

        public ToolType RequiredTool => _requiredTool;

        public abstract void Interact();
    }
}