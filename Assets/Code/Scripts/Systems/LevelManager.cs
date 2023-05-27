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

            //Отключение курсора во время загрузки
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Sequence loadingScreen = DOTween.Sequence();
            loadingScreen
                .AppendInterval(1)
                .Append(loaderCanvasGroup.DOFade(0, 1))
                .AppendCallback((() =>
                {
                    DOTween.Clear();
                    loaderCanvas.SetActive(false);
                    //Включение курсора
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }));
        }

        //Загрузка сцены асинхронно
        public AsyncOperation LoadSceneAsync(string sceneName)
        {
            LoadScene(sceneName);
            return new AsyncOperation();
        }
    }
}