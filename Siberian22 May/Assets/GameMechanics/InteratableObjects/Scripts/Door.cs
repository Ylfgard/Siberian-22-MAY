using UnityEngine;

namespace InteractableObjects
{
    public class Door : InteractableObject
    {
        public override void Interact()
        {
            base.Interact();
            Destroy(gameObject);
        }
    }
}