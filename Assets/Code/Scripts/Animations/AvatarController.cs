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
            if (movementDirection.x > 0)
                playerAvatar.localScale = Vector3.one;
            else if (movementDirection.x < 0)
                playerAvatar.localScale = new Vector3(-1, 1, 1);
            else
                playerAvatar.localScale = playerAvatar.localScale;
        }
    }
}