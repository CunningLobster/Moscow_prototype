using UnityEngine;

namespace Code.Scripts.Levels
{
    public class ParkFlow : MonoBehaviour
    {
        void Start()
        {
            var music = SoundManager.Instance.LoadClip(SoundManager.NameOfSound.ThunderWeather);
            SoundManager.Instance.PlaySituationSound(music);
        }
    }
}
