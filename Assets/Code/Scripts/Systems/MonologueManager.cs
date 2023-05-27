using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Systems
{
    public class MonologueManager : MonoBehaviour
    {
        public static MonologueManager Instance;

        [SerializeField] private Image dialogueFrame;
        [SerializeField] private TextMeshProUGUI frameText;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void ShowMonologue(MonologueComponent monologue)
        {
            frameText.text = monologue.MonologueText;
            frameText.DOFade(1, 1);
            dialogueFrame.DOFade(0.7f, 1);
        }

        public void HideMonologue()
        {
            frameText.DOFade(0, 1);
            dialogueFrame.DOFade(0, 1);
        }
    }
}

