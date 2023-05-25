using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Systems
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [SerializeField] private GameObject loaderCanvas;
        [SerializeField] private CanvasGroup loaderCanvasGroup;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            loaderCanvasGroup.alpha = 1;

            SceneManager.LoadScene(sceneName);
            loaderCanvas.SetActive(true);

            Sequence loadingScreen = DOTween.Sequence();
            loadingScreen
                .AppendInterval(3)
                .Append(loaderCanvasGroup.DOFade(0, 1))
                .AppendCallback((() =>
                {
                    DOTween.Clear();
                    loaderCanvas.SetActive(false);
                }));
        }
    }
}