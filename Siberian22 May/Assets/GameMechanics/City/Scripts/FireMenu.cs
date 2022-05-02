using UnityEngine;
using TMPro;
using Menu;

namespace City
{
    public class FireMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _menuWindow;
        [SerializeField]
        private TextMeshProUGUI _time;
        [SerializeField]
        private TextMeshProUGUI _people;
        [SerializeField]
        private TextMeshProUGUI _fires;
        [SerializeField]
        private TextMeshProUGUI _difficult;
        private FireData _fireData;

        public FireData FireData => _fireData;

        public void ShowFireMenu(FireData fireData)
        {
            _menuWindow.SetActive(true);
            int min = Mathf.FloorToInt(fireData.Time / 60);
            int sec = (int)fireData.Time - min * 60;
            if(sec < 10) _time.text = min.ToString() + ":0" + sec.ToString();
            else _time.text = min.ToString() + ":" + sec.ToString();
            _people.text = fireData.People.ToString();
            _fires.text = fireData.Fires.ToString();
            _difficult.text = fireData.Difficult.ToString() + "%";
            _fireData = fireData;
        }

        public void ActivateLevel()
        {
            FindObjectOfType<LevelLoader>().LoadLevel(_fireData);
        }
    }
}