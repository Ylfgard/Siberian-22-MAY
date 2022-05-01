using UnityEngine;
using InventorySystem;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        private ToolTypes _requiredTool;

        public ToolTypes RequiredTool => _requiredTool;

        public abstract void Interact();
    }
}