using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _slowRun = Animator.StringToHash("Slow Run");
    private int _happyIdle = Animator.StringToHash("Happy Idle");

    public void SetAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void DoMove(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
