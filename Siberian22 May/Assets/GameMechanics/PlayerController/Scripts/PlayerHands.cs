using UnityEngine;
using InventorySystem;

namespace PlayerController
{
    public class PlayerHands : MonoBehaviour
    {
        public event EventHappaned PeopleRescued;
        [SerializeField]
        private GameObject _withPeopleIcon;
        private Inventory _inventory;
        private ToolType _toolInHands;
        private bool _withPeople;

        public ToolType ToolInHands => _toolInHands;
        public bool WithPeople => _withPeople;

        private void Awake()
        {
            _inventory = FindObjectOfType<Inventory>();  
            _inventory.ToolSelected += TakeToolInHands;
            _withPeopleIcon.SetActive(false);
        }

        public void SelectToolInSlot(int number)
        {
            if(_withPeople) return;
            number -= 1;
            _inventory.SelectToolInSlot(number);
        }

        private void TakeToolInHands(ToolType tool)
        {
            _toolInHands = tool;
        }


        public void GrabPeople()
        {
            TakeToolInHands(ToolType.None);
            _inventory.ChangeInteractionState(false);
            _withPeople = true;
            _withPeopleIcon.SetActive(true);
        }

        public void RescuePeople()
        {
            _inventory.ChangeInteractionState(true);
            _withPeople = false;
            _withPeopleIcon.SetActive(false);
            PeopleRescued?.Invoke();
        }
    }
}