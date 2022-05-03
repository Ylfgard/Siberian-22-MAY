using UnityEngine;
using UnityEngine.SceneManagement;
using City;
using LocationLoadingSystem;

namespace Menu
{
    public class LevelLoader : MonoBehaviour
    {
        private void Awake() 
        {
            Time.timeScale = 1;    
        }

        public void LoadLevel(FireData fireData)
        {
            LoadDataKeeper.Instance.SetFireData(fireData);
            SceneManager.LoadScene(fireData.LevelName);
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}