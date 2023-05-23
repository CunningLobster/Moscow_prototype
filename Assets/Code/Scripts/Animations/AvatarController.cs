using UnityEngine;

namespace Code.Scripts.Animations
{
    public class AvatarController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Transform playerAvatar;
        private static readonly int Speed = Animator.StringToHash("Speed");

        public void AnimateMove(Vector2 movementDirection) =>
            playerAnimator.SetFloat(Speed, movementDirection != Vector2.zero ? 1 : 0);

        public void FlipSprite(Vector2 movementDirection)
        {
            playerAvatar.localScale = movementDirection.x switch
            {
                > 0 => Vector3.one,
                < 0 => new Vector3(-1, 1, 1),
                _ => playerAvatar.localScale
            };
        }
    }
}