using UnityEngine;
using UnityEngine.SceneManagement;
using City;
using LocationLoadingSystem;

namespace Menu
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(FireData fireData)
        {
            LoadDataKeeper.Instance.SetFireData(fireData);
            SceneManager.LoadScene(fireData.LevelName);
        }
    }
}