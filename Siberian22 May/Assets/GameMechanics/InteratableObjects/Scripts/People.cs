using PlayerController;

namespace InteractableObjects
{
    public class People : InteractableObject
    {
        public override void Interact()
        {
            FindObjectOfType<PlayerHands>().GrabPeople();
            Destroy(gameObject);
        }
    }
}