using Code.Scripts.Systems;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.UI.MainMenu
{
    public class ChangeSceneButton : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            DOTween.Clear();
            SceneManager.LoadScene(sceneName);
        }
    }
}
