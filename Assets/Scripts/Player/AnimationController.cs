using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    private bool isThrowed; 

    private Animator animator;
    private InputInfo inputInfo;

    public event Action onIndicateBallMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Init(InputInfo _inputInfo)
    {
        inputInfo = _inputInfo;
    }

    private void OnEnable()
    {
        inputInfo.onPressDown += Play_ThrowAnimation;
    }

    private void OnDisable()
    {
        inputInfo.onPressDown -= Play_ThrowAnimation;
    }

    private void Play_ThrowAnimation() 
    {
        if (!isThrowed)
        {
            animator.SetTrigger("Throw");
            isThrowed = true;
        }
    }

    public void Throw()
    {
        if (onIndicateBallMoving != null)
            onIndicateBallMoving();
    }
}
