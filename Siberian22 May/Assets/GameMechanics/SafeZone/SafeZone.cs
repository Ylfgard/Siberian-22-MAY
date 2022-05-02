using UnityEngine;
using PlayerController;
using InventorySystem;

namespace SafeZone
{
    public class SafeZone : MonoBehaviour
    {
        private ToolStorage _toolStorage;

        private void Awake()
        {
            _toolStorage = FindObjectOfType<ToolStorage>();    
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerHands>();
            if(player == null) return;
            EnterSafeZone();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerHands>();
            if(player == null) return;
            ExitSafeZone();
        }

        private void EnterSafeZone()
        {
            _toolStorage.ShowToolStorage();
        }

        private void ExitSafeZone()
        {
            _toolStorage.HideToolStorage();
        }
    }
}