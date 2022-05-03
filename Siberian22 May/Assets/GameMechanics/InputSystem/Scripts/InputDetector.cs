using UnityEngine;
using Menu;

namespace InputSystem
{
    public class InputDetector : MonoBehaviour
    {   
        [SerializeField]
        private LevelLoader _loader;
        [SerializeField]
        private MapInputHandler _mapInputHandler;
        [SerializeField]
        private LevelInputHandler _levelInputHandler;
        [SerializeField]
        private InputState _inputState;
        [SerializeField]
        private LayerMask _selectable;

        private void Update()
        {
            if(Input.GetButtonDown("Menu"))
                _loader.ChangeMenuState();

            switch(_inputState)
            {
                case InputState.Map:
                    if(Input.GetButtonDown("Select"))
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if(Physics.Raycast(ray, out hit, Mathf.Infinity, _selectable))
                            _mapInputHandler.SelectBuilding(hit.collider);
                    }
                break;

                case InputState.Level:
                    var hor = Input.GetAxisRaw("Horizontal");
                    var ver = Input.GetAxisRaw("Vertical");
                    if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")
                        || Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
                        _levelInputHandler.DirectionInput(hor, ver);

                    if(Input.GetButtonDown("Interact"))
                        _levelInputHandler.InteractInput();

                    if(Input.GetButtonDown("Slot1"))
                        _levelInputHandler.SelectSlot(1);
                    
                    // if(Input.GetButtonDown("Slot2"))
                    //     _levelInputHandler.SelectSlot(2);
                    
                    // if(Input.GetButtonDown("Slot3"))
                    //     _levelInputHandler.SelectSlot(3);
                break;
            }
        }
    }

    public enum InputState
    {
        Map,
        Level
    }
}