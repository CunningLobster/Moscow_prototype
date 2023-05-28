using UnityEngine;

namespace Code.Scripts.Systems
{
    public class MonologueComponent : MonoBehaviour
    {
        [TextArea] public string MonologueText; //Текст, который будет появляться в окне мыслей ГГ 

        [SerializeField] private Animator playerAnimator;

        private static readonly int Think = Animator.StringToHash("Think");
        private static readonly int Interact = Animator.StringToHash("Interact");

        //Вызывать этот метод, чтобы показать мысли персонажа
        public void Action()
        {
            MonologueManager.Instance.ShowMonologue(this);
            if (playerAnimator != null) playerAnimator.SetTrigger(Interact);
        }

        public void Observ()
        {
            MonologueManager.Instance.ShowMonologue(this);
            if (playerAnimator != null) playerAnimator.SetTrigger(Think);
        }
    }
}