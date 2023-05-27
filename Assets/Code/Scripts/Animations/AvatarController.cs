using System;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Scripts.Animations
{
    public class AvatarController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Transform playerTransform;
        private NavMeshAgent playerAgent;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Start()
        {
            playerAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (playerAgent.velocity.x > 0)
            {
                playerTransform.localScale = Vector3.one;
                playerTransform.eulerAngles = new Vector3(0,0,-12);
                playerAnimator.SetFloat(Speed, 1);
            }
            else if (playerAgent.velocity.x < 0)
            {
                playerTransform.localScale = new Vector3(-1, 1, 1);
                playerTransform.eulerAngles = new Vector3(0,0,12);
                playerAnimator.SetFloat(Speed, 1);
            }
            else
            {
                playerAnimator.SetFloat(Speed, 0);
            }
        }
    }
}