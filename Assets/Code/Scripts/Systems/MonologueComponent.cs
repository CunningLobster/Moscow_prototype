using UnityEngine;

namespace Code.Scripts.Systems
{
    public class MonologueComponent : MonoBehaviour
    {
        [TextArea] public string MonologueText; //Текст, который будет появляться в окне мыслей ГГ 

        //Вызывать этот метод, чтобы показать мысли персонажа
        public void Interact() => MonologueManager.Instance.ShowMonologue(this);
    }
}