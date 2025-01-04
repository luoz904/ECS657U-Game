using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public EnemyGoblinAnimator animator;
    public enemyMovement mover;
    public Enemy status;

    public void OnMoveForward()
    {
        animator.SetAnimationState(EnemyState.BattleIdle);
        animator.SetAnimationState(EnemyState.Run);
    }
}