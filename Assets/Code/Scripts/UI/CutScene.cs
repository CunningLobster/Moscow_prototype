using System.Collections.Generic;
using Code.Scripts.Systems;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI
{
    public class CutScene : MonoBehaviour
    {
        [SerializeField] private List<float> delays = new();
        [SerializeField] private List<Image> splashScreens = new();
        [SerializeField] private List<MonologueComponent> monologueList = new();
        
        

        private void Start()
        {
            if (LevelManager.Instance.FirstPlay)
            {
                gameObject.SetActive(false);
                return;
            }
            Sequence presentation = DOTween.Sequence();

            for (int i = 0; i < splashScreens.Count; i++)
            {
                var i1 = i;
                presentation
                    .AppendCallback(() => monologueList[i1].Observ())
                    .Join(splashScreens[i].DOFade(1, 1))
                    .AppendInterval(delays[i])
                    .AppendCallback(() => MonologueManager.Instance.HideMonologue())
                    .Join(splashScreens[i].DOFade(0, 1));
            }

            presentation.AppendCallback(() =>
            {
                LevelManager.Instance.FirstPlay = true;
                gameObject.SetActive(false);
            });

        }
    }
}