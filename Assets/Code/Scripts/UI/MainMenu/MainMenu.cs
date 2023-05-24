using DG.Tweening;
using UnityEngine;

namespace Code.Scripts.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup teamLogo;
        [SerializeField] private CanvasGroup gameTitle;
        [SerializeField] private CanvasGroup mainMenu;
        [SerializeField] private CanvasGroup parallaxBackground;

        private void Start()
        {
            Sequence gameIntroduce = DOTween.Sequence();

            gameIntroduce
                .Append(teamLogo.DOFade(1, 1).SetEase(Ease.OutCubic))
                .Append(teamLogo.DOFade(0, 1).SetEase(Ease.InCubic))
                .Append(gameTitle.DOFade(1, 1).SetEase(Ease.OutCubic))
                .Append(gameTitle.DOFade(0, 1).SetEase(Ease.InCubic))
                .Append(mainMenu.DOFade(1, 1))
                .Insert(4.5f, parallaxBackground.DOFade(1, 1).SetEase(Ease.OutCubic));
        }

        public void ExitGame()
        {
            Sequence gameExit = DOTween.Sequence();
        
#if UNITY_EDITOR

            gameExit
                .Append(parallaxBackground.DOFade(0, 1).SetEase(Ease.InCubic))
                .Join(mainMenu.DOFade(0, 1).SetEase(Ease.InCubic))
                .AppendInterval(1)
                .AppendCallback(() => UnityEditor.EditorApplication.isPlaying = false);
        
#endif
        
            gameExit
                .Append(parallaxBackground.DOFade(0, 1).SetEase(Ease.InCubic))
                .Join(mainMenu.DOFade(0, 1).SetEase(Ease.InCubic))
                .AppendInterval(1)
                .AppendCallback(Application.Quit);
        }
    }
}