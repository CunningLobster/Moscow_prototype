using Code.Scripts.Systems;
using DG.Tweening;
using UnityEngine;

namespace Code.Scripts.UI.MainMenu
{
    public class ChangeSceneButton : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            DOTween.Clear();
            LevelManager.Instance.LoadScene(sceneName);
        }
    }
}
