using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private InventorySlot[] _slots;
        private int selectedSlot;

        public ToolTypes SelectToolInSlot(int index)
        {
            var slot = _slots[index];
            slot.SelectSlot();
            return slot.ToolInSlot;
        }
    }

    public enum ToolTypes
    {
        None,
        Axe
    }
}