using UnityEngine;
using City;

namespace InputSystem
{
    public class MapInputHandler : MonoBehaviour
    {
        private FireMenu _fireMenu;

        private void Awake()
        {
            _fireMenu = FindObjectOfType<FireMenu>();
        }

        public void SelectBuilding(Collider input)
        {
            var building = input.GetComponent<Building>();
            if(building == null) return;
            if(building.OnFire == false) return;
            _fireMenu.ShowFireMenu(building.FireData);
        }
    }
}