using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class EnemyAnimator : MonoBehaviour
{
    public Animator anim;

	public abstract void SetAnimationState(EnemyState state);
}