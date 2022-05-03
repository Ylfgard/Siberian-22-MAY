using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        public event SendTool ToolSelected;
        [SerializeField]
        private Image _image;
        private Toggle _toggle;
        private ToolType _toolInSlot;
        
        public ToolType ToolInSlot => _toolInSlot;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        public void Initialize(ToolSO tool)
        {
            _toolInSlot = tool.Type;
            _image.sprite = tool.Sprite;
            _toggle.isOn = false;
        }

        public void SelectSlot()
        {
            _toggle.isOn = true;
        }

        public void SlotActiveChanged(bool state)
        {
            if(state) ToolSelected?.Invoke(_toolInSlot);
        }

        public void ChangeInteractionState(bool state)
        {
            _toggle.interactable = state;
            _toggle.isOn = false;
        }
    }
}
