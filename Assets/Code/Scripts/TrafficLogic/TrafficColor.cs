using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Scripts.TrafficLogic
{
    public class TrafficColor : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        public void ChangeColor(Color32 color)
        {
            Color2 startColor = new (lineRenderer.startColor, lineRenderer.endColor);
            Color2 endColor = new(color, color);
            lineRenderer.DOColor(startColor, endColor, 1);
        }
    }
}
