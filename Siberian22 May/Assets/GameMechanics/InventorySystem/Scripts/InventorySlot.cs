using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        private Image _image;
        private Button _button;
        [SerializeField]
        private ToolTypes _toolInSlot;
        
        public ToolTypes ToolInSlot => _toolInSlot;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        public void Initialize(Sprite sprite, ToolTypes toolType)
        {
            _toolInSlot = toolType;
            _image.sprite = sprite;
            DeselectSlot();
        }

        public void SelectSlot()
        {
            _image.color = _button.colors.pressedColor;
        }

        public void DeselectSlot()
        {
            _image.color = _button.colors.normalColor;
        }
    }
}
