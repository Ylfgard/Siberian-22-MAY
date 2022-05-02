using UnityEngine;
using System.Collections.Generic;

namespace City
{
    public class FireGenerator : MonoBehaviour
    {
        [SerializeField] [Range (1, 3)]
        private int _firesCount;

        private void Start()
        {
            var buildings = FindObjectsOfType<Building>();
            List<int> indexes = new List<int>();
            for(int i = 0; i < _firesCount; i++)
            {
                bool flag = true;
                int index;
                do
                {   
                    index = Random.Range(0, buildings.Length);
                    flag = indexes.Contains(index);
                } 
                while (flag);
                indexes.Add(index);
                GenerateFire(buildings[index]);
            }
        }

        private void GenerateFire(Building building)
        {
            building.StartFire();
        }
    }   
}