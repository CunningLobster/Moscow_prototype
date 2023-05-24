using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI.MainMenu
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private List<RawImage> images = new();
        private void Start()
        {
            for (var index = 0; index < images.Count; index++)
            {
                var image = images[index];
                DOTween.To(() =>
                    image.uvRect, x => image.uvRect = x, new Rect(1, 0, 1, 1), 1 + index * 10).SetEase(Ease.Linear).SetLoops(-1);
            }
        }
    }
}
