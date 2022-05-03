using UnityEngine;
using System.Collections.Generic;
using InteractableObjects;

namespace FogOfWar
{
    public class FireFieldOfView : FieldOfView
    {
        private Fire _fire;

        public void AddFire(Transform fire)
        {
            gameObject.SetActive(true);
            SetOrigin(fire.transform);
        }
    }
}