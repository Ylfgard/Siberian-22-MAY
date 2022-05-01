using UnityEngine;
using PlayerController;

namespace InputSystem
{
    public class LevelInputHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;
        private PlayerMovement _playerMovement;
        private PlayerInteraction _playerInteraction;
        private PlayerHands _playerHands;

        private void Awake()
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
            _playerInteraction = _player.GetComponent<PlayerInteraction>();
            _playerHands = _player.GetComponent<PlayerHands>();
        }

        public void DirectionInput(float horizInput, float vertInput)
        {
            Vector2 dir = new Vector2(horizInput, vertInput).normalized;
            _playerMovement.MoveInDirection(dir);
        }

        public void InteractInput()
        {
            _playerInteraction.Interact();
        }

        public void SelectSlot(int number)
        {
            _playerHands.SelectToolInSlot(number);
        }
    }
}