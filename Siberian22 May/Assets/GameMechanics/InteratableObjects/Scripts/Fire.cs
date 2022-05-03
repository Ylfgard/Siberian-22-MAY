using FogOfWar;
using UnityEngine;

namespace InteractableObjects
{
    public class Fire : InteractableObject
    {
        [SerializeField]
        private FireFieldOfView _fireFieldOfView;

        private void Awake()
        {
            _fireFieldOfView.AddFire(this.transform);
            _fireFieldOfView.gameObject.SetActive(false);
        }

        public void Activate()
        {
            _fireFieldOfView.gameObject.SetActive(true);
        }

        public override void Interact()
        {
            base.Interact();
            Interacted?.Invoke();
            Destroy(_fireFieldOfView.gameObject);
            Destroy(gameObject);
        }
    }
}