using UnityEngine;
using System.Collections.Generic;
using InventorySystem;
using City;

namespace LocationLoadingSystem
{
    public class LoadDataKeeper : MonoBehaviour
    {
        public static LoadDataKeeper Instance { get; private set; }

        [SerializeField]
        private List<ToolSO> _availableTools;
        private FireData _fireData;

        public ToolSO[] AvailableTools => _availableTools.ToArray();
        public FireData FireData => _fireData;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }    
            Destroy(gameObject);
        }

        public void AddAvailableTool(ToolSO tool)
        {
            _availableTools.Add(tool);
        }

        public void SetFireData(FireData fireData)
        {
            _fireData = fireData;
        }

        public void DestroyKeeper()
        {
            Destroy(gameObject);
        }
    }
}