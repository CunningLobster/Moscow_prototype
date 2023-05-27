using UnityEngine;

namespace Code.Scripts.Systems
{
    public class MonologueComponent : MonoBehaviour
    {
        [TextArea] public string MonologueText; //Текст, который будет появляться в окне мыслей ГГ 

        [SerializeField] private Animator playerAnimator;

        private static readonly int Think = Animator.StringToHash("Think");

        //Вызывать этот метод, чтобы показать мысли персонажа
        public void Interact()
        {
            MonologueManager.Instance.ShowMonologue(this);
            if (playerAnimator != null) playerAnimator.SetTrigger(Think);
        }
    }
}