using System.Collections.Generic;
using UnityEngine;
using InteractableObjects;
using InventorySystem;

namespace PlayerController
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private PlayerHands _hands;
        
        [Header ("Parametrs")]
        [SerializeField]
        private float _radius;
        [SerializeField]
        private LayerMask _interactableLeyer;
        private InteractableObject _objectInZone;

        public void Interact()
        {
            if(_objectInZone == null) return;

            if(_objectInZone.RequiredTool == ToolTypes.None ||
                 _objectInZone.RequiredTool == _hands.ToolInHands)
                _objectInZone.Interact();
        }

        private void Update()
        {
            var objectsInZone = Physics2D.OverlapCircleAll(_transform.position, _radius, _interactableLeyer);
            if(objectsInZone.Length > 0) _objectInZone = objectsInZone[0].GetComponent<InteractableObject>();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_transform.position, _radius);
        }
    }
}