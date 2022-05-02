using UnityEngine;

namespace InventorySystem
{
    public  delegate void SendTool(ToolType tool);

    public class Inventory : MonoBehaviour
    {
        public event SendTool ToolSelected;
        [SerializeField]
        private ToolSO _emptySlot;
        [SerializeField]
        private InventorySlot[] _slots;
        private int selectedSlot;

        public InventorySlot[] Slots => _slots;

        private void Awake()
        {
            foreach(var slot in _slots)
            {
                slot.ToolSelected += SelectTool;
                slot.Initialize(_emptySlot);
            }
        }
        
        public bool AddTool(ToolSO tool)
        {
            foreach(var slot in _slots)
            {
                if(slot.ToolInSlot == ToolType.None)
                {
                    slot.Initialize(tool);
                    return true;
                }
            }
            return false;
        }

        public void RemoveTool(ToolSO tool)
        {
            foreach(var slot in _slots)
            {
                if(slot.ToolInSlot == tool.Type)
                {
                    slot.Initialize(_emptySlot);
                    return;
                }
            }
        }

        public void SelectToolInSlot(int index)
        {
            var slot = _slots[index];
            slot.SelectSlot();
        }

        public void SelectTool(ToolType tool)
        {
            ToolSelected.Invoke(tool);
        }
    }
}