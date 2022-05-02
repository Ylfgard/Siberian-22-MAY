using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class StorageSlot : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Toggle _toggle;
        private ToolSO _toolInSlot;
        private Inventory _inventory;

        public void Initialize(ToolSO tool, Inventory inventory)
        {
            _toolInSlot = tool;
            _image.sprite = tool.Sprite;
            _inventory = inventory;
            _toggle.isOn = false;
        }

        public void SlotActiveChanged(bool state)
        {
            if(state)
            {
                if(_inventory.AddTool(_toolInSlot) == false)
                    _toggle.isOn = false;
            }
            else
            {
                _inventory.RemoveTool(_toolInSlot);
            }
        }
    }
}