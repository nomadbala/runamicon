using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField] private float _changeAnimationDelay;

    [SerializeField] private int _animationsAmount;

    private bool _isChangeAnimation;
    private float _idleTime;

    // Animator parameters
    private int _idleAnimationParameterHash = Animator.StringToHash("IdleAnimation");

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle(animator);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isChangeAnimation)
        {
            _idleTime += Time.deltaTime;
            if (_idleTime > _changeAnimationDelay)
            {
                _isChangeAnimation = true;
                int animationIndex = Random.Range(1, _animationsAmount + 1);
                animator.SetFloat(_idleAnimationParameterHash, animationIndex);
                Debug.Log(animationIndex + " " + animator.GetFloat(_idleAnimationParameterHash));
            }
        }

        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle(animator);
        }
    }

    private void ResetIdle(Animator animator)
    {
        _isChangeAnimation = false;
        _idleTime = 0;

        animator.SetFloat(_idleAnimationParameterHash, 0);
    }
}
