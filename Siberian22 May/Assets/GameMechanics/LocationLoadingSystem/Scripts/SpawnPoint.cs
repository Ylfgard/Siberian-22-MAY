using UnityEngine;

namespace LocationLoadingSystem
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private SpawnPointType _type;
        [SerializeField]
        private GameObject _object;

        public SpawnPointType Type => _type;
        public GameObject Object => _object;
        
        private void Awake()
        {
            _object.SetActive(false);    
        }
    }

    public enum SpawnPointType
    {
        People,
        Fire,
        Obstacle
    }
}