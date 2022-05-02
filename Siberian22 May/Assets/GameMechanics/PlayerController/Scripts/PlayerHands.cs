using UnityEngine;
using InventorySystem;

namespace PlayerController
{
    public class PlayerHands : MonoBehaviour
    {
        private Inventory _inventory;
        private ToolType _toolInHands;

        public ToolType ToolInHands => _toolInHands;

        private void Awake()
        {
            _inventory = FindObjectOfType<Inventory>();  
            _inventory.ToolSelected += TakeToolInHands;
        }

        public void SelectToolInSlot(int number)
        {
            number -= 1;
            _inventory.SelectToolInSlot(number);
        }

        private void TakeToolInHands(ToolType tool)
        {
            _toolInHands = tool;
        }
    }
}