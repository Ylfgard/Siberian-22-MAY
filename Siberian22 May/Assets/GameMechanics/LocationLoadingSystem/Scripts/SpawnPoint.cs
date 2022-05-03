using UnityEngine;
using InteractableObjects;

public delegate void EventHappaned();

namespace LocationLoadingSystem
{
    public class SpawnPoint : MonoBehaviour
    {
        public event EventHappaned ObjectInteracted;
        [SerializeField]
        private SpawnPointType _type;
        [SerializeField]
        private GameObject _object;

        public SpawnPointType Type => _type;
        public GameObject Object => _object;
        
        private void Awake()
        {
            _object.SetActive(false);  
            _object.GetComponent<InteractableObject>().Interacted.AddListener(SendObjectType);
        }

        private void SendObjectType()
        {
            ObjectInteracted?.Invoke();
        }
    }

    public enum SpawnPointType
    {
        People,
        Fire,
        Obstacle
    }
}