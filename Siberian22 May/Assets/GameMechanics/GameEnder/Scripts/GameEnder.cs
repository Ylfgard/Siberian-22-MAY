using LocationLoadingSystem;
using UnityEngine;

namespace GameEndSystem
{
    public class GameEnder : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOverWindow;
        [SerializeField]
        private GameObject _winGameWindow;
        private bool _peopleRescued;
        private bool _fireExtinguished;

        public void Initialize(EndGameViewer viewer, EndGameTimer timer)
        {
            timer.TimeOut += GameOver;
            _peopleRescued = false;
            _fireExtinguished = false;
            viewer.AllPeopleRescued += PeopleRescued;
            viewer.AllFiresExtinguished += FiresExtinguished;
        }

        private void PeopleRescued()
        {
            _peopleRescued = true;
            if(_fireExtinguished) GameWin();
        }

        private void FiresExtinguished()
        {
            _fireExtinguished = true;
            if(_peopleRescued) GameWin();
        }

        private void GameOver()
        {
            _gameOverWindow.SetActive(true);
            Destroy(LoadDataKeeper.Instance.gameObject);
            Time.timeScale = 0;
        }

        private void GameWin()
        {
            _winGameWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}