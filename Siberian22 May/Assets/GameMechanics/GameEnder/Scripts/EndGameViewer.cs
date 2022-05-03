using UnityEngine;
using System.Collections.Generic;
using LocationLoadingSystem;
using PlayerController;

namespace GameEndSystem
{
    public class EndGameViewer : MonoBehaviour
    {
        public event EventHappaned AllPeopleRescued;
        public event EventHappaned AllFiresExtinguished;
        private int _people;
        private int _fire;

        public void StartGame(float time, int people, int fire, List<SpawnPoint> fires)
        {
            _people = people;
            FindObjectOfType<PlayerHands>().PeopleRescued += PeopleRescued;
            
            _fire = fire;
            foreach(var f in fires)
                f.ObjectInteracted += FireExtinguished;

            var timer = FindObjectOfType<EndGameTimer>();
            timer.StartTimer(time);
            FindObjectOfType<GameEnder>().Initialize(this, timer);
            if(people <= 0) PeopleRescued();
        }

        private void PeopleRescued()
        {
            _people--;
            if(_people <= 0) AllPeopleRescued?.Invoke();
        }

        private void FireExtinguished()
        {
            _fire--;
            if(_fire <= 0) AllFiresExtinguished?.Invoke();
        }
    }
}