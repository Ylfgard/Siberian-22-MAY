using UnityEngine;

namespace City
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private GameObject _fireAlarm;
        [SerializeField]
        private string _levelName;
        [SerializeField]
        Vector2 _time;
        [SerializeField]
        Vector2 _people;
        [SerializeField]
        Vector2 _fires;
        [SerializeField]
        Vector2 _difficult;
        private bool _onFire;
        private FireData _fireData;

        public bool OnFire => _onFire;
        public FireData FireData => _fireData;

        public void StartFire()
        {
            _onFire = true;
            _fireAlarm.SetActive(true);
            float time = Random.Range(_time.x, _time.y);
            int people = (int)Random.Range(_people.x, _people.y);
            int fires = (int)Random.Range(_fires.x, _fires.y);
            int difficult = (int)Random.Range(_difficult.x, _difficult.y);
            _fireData = new FireData(_levelName, time, people, fires, difficult);
        }
    }

    public class FireData
    {
        string _levelName;
        float _time;
        int _people;
        int _fires;
        int _difficult;

        public string LevelName => _levelName;
        public float Time => _time;
        public int People => _people;
        public int Fires => _fires;
        public int Difficult => _difficult;

        public FireData(string levelName, float time, int people, int fires, int difficult)
        {
            _levelName = levelName;
            _time = time;
            _people = people;
            _fires = fires;
            _difficult = difficult;
        }
    }
}