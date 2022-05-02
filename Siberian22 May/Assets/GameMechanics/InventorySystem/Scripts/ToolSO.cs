using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu (fileName = "New Tool", menuName = "Scriptable Objects/Inventory System/Tool")]
    public class ToolSO : ScriptableObject
    {
        [SerializeField]
        private ToolType _type;
        [SerializeField]
        private Sprite _sprite;
        
        public ToolType Type => _type;
        public Sprite Sprite => _sprite;
    }
}