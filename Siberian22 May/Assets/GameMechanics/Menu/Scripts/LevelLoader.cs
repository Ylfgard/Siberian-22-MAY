using UnityEngine;
using UnityEngine.SceneManagement;
using City;
using LocationLoadingSystem;

namespace Menu
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField]
        private GameObject _menuWindow;

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

        public void Exit()
        {
            Application.Quit();
        }

        public void ChangeMenuState()
        {
            _menuWindow.SetActive(!_menuWindow.activeSelf);
            if(_menuWindow.activeSelf) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}