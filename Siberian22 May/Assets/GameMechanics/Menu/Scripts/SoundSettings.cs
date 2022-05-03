using UnityEngine;
using FMOD.Studio;
using UnityEngine.UI;

namespace Menu
{
    public class SoundSettings : MonoBehaviour
    {
        private Bus _busController;
        private Slider _slider;
        [SerializeField]
        private string _busName;

        private void Awake()
        {
            _busController = FMODUnity.RuntimeManager.GetBus("bus:/" + _busName);
            _slider = GetComponent<Slider>();
            float volume;
            _busController.getVolume(out volume);
            _slider.value = volume;
        }

        public void SetVolume(float volume)
        {
            Debug.Log("SetVolume");
            _busController.setVolume(volume);
        }
    }
}