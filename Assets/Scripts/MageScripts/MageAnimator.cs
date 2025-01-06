using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MageState {
    Idle,
    Attack,
    Upgrade,
    Die,
}

public abstract class MageAnimator : MonoBehaviour
{
    public Animator anim;

	public abstract void SetAnimationState(MageState state);
}