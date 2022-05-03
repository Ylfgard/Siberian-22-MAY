using PlayerController;

namespace InteractableObjects
{
    public class People : InteractableObject
    {
        public override void Interact()
        {
            base.Interact();
            FindObjectOfType<PlayerHands>().GrabPeople();
            Destroy(gameObject);
        }
    }
}