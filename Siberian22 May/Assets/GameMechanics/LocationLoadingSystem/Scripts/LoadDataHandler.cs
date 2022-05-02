using UnityEngine;
using System.Collections.Generic;

namespace LocationLoadingSystem
{
    public class LoadDataHandler : MonoBehaviour
    {
        private List<SpawnPoint> _peoples, _fires, _obstacles; 

        private void Awake()
        {
            var spawnPoints = FindObjectsOfType<SpawnPoint>();
            _peoples = new List<SpawnPoint>();
            _fires = new List<SpawnPoint>();
            _obstacles = new List<SpawnPoint>();
            foreach(var spawnPoint in spawnPoints)
            {
                switch(spawnPoint.Type)
                {
                    case SpawnPointType.People:
                        _peoples.Add(spawnPoint);
                    break;

                    case SpawnPointType.Fire:
                        _fires.Add(spawnPoint);
                    break;

                    case SpawnPointType.Obstacle:
                        _obstacles.Add(spawnPoint);
                    break;
                }
            }    
        }

        private void Start()
        {
            var data = LoadDataKeeper.Instance.FireData;
            for(int i = 0; i < data.People; i++)
            {   
                var index = Random.Range(0, _peoples.Count);
                _peoples[index].Object.SetActive(true);
                _peoples.Remove(_peoples[index]);
            }

            for(int i = 0; i < data.Fires; i++)
            {   
                var index = Random.Range(0, _fires.Count);
                _fires[index].Object.SetActive(true);
                _fires.Remove(_fires[index]);
            }
            
            var percent = data.Difficult / 100;
            int obstacleCount = _obstacles.Count * percent;

            for(int i = 0; i < obstacleCount; i++)
            {
                var index = Random.Range(0, _obstacles.Count);
                _obstacles[index].Object.SetActive(true);
                _obstacles.Remove(_obstacles[index]);
            }
        }
    }
}