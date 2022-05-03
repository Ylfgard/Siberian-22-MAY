using UnityEngine;
using UnityEngine.UI;

namespace GameEndSystem
{
    public class EndGameTimer : MonoBehaviour
    {
        public event EventHappaned TimeOut;
        [SerializeField]
        private Slider _slider;

        public void StartTimer(float time)
        {
            _slider.maxValue = time;
            _slider.value = 0;
        }

        private void Update() 
        {
            _slider.value += Time.deltaTime;
            if(_slider.value >= _slider.maxValue)
            {
                TimeOut?.Invoke();
                Destroy(gameObject);
            } 
        }
    }
}