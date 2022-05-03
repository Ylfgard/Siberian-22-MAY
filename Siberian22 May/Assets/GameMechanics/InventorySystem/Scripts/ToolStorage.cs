using UnityEngine;
using LocationLoadingSystem;

namespace InventorySystem
{
    public class ToolStorage : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private GameObject _storageSlot;
        [SerializeField]
        private Transform _storageTransform;
        [SerializeField]
        private ToolSO[] _tools;
        
        private void Start()
        {
            _tools = LoadDataKeeper.Instance.AvailableTools;
            foreach(var tool in _tools)  
            {
                var slot = Instantiate(_storageSlot, _storageTransform).GetComponent<StorageSlot>();
                slot.Initialize(tool, _inventory);
            }
        }
        
        public void ShowToolStorage()
        {
            _storageTransform.gameObject.SetActive(true);
        }

        public void HideToolStorage()
        {
            _storageTransform.gameObject.SetActive(false);
        }
    }

    public enum ToolType
    {
        None,
        Axe,
        Extinguisher
    }
}