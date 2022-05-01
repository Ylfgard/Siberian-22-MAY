using UnityEngine;

namespace InputSystem
{
    public class InputDetector : MonoBehaviour
    {   
        [SerializeField]
        private MapInputHandler _mapInputHandler;
        [SerializeField]
        private LevelInputHandler _levelInputHandler;
        private bool _inputDeactivated;
        [SerializeField]
        private InputState _inputState;

        private void Awake()
        {
            
        }

        private void Update()
        {
            if(_inputDeactivated) return;

            switch(_inputState)
            {
                case InputState.Map:
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
                    
                    if(Input.GetButtonDown("Slot2"))
                        _levelInputHandler.SelectSlot(2);
                    
                    if(Input.GetButtonDown("Slot3"))
                        _levelInputHandler.SelectSlot(3);
                break;
            }
        }

        public void DeactivateInput()
        {
            _inputDeactivated = true;
        }

        public void ActivateInput()
        {
            _inputDeactivated = false;
        }
    }

    public enum InputState
    {
        Map,
        Level
    }
}