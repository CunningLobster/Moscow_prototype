using UnityEngine;

namespace Code.Scripts.TrafficLogic
{
    public class TrafficButton : MonoBehaviour
    {
        [SerializeField] private Color32 color;

        [SerializeField] private TrafficColor trafficColor;

        public void AcceptColor()
        {
            trafficColor.ChangeColor(color);
        }
    }
}