using UnityEngine;

namespace Code.Scripts.Animations
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private Animator npcAnimator;
        
        public void TriggerAnimation(string trigger)
        {
            npcAnimator.SetTrigger(trigger);    
        }
    }
}
