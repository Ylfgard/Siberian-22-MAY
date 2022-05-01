using UnityEngine;
using InventorySystem;

namespace PlayerController
{
    public class PlayerHands : MonoBehaviour
    {
        private Inventory _inventory;
        private ToolTypes _toolInHands;

        public ToolTypes ToolInHands => _toolInHands;

        private void Awake()
        {
            _inventory = FindObjectOfType<Inventory>();    
        }

        public void SelectToolInSlot(int number)
        {
            number -= 1;
            _toolInHands = _inventory.SelectToolInSlot(number);
        }
    }
}