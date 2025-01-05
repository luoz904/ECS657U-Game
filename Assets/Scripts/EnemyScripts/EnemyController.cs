using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public EnemyGoblinAnimator animator;
    public enemyMovement mover;
    public Enemy status;
    public EnemyPathSeeker router;

    public void OnMoveForward()
    {
        animator.SetAnimationState(EnemyState.BattleIdle);
        animator.SetAnimationState(EnemyState.Run);
    }

    public void OnChangeTarget(Transform target)
    {
        Debug.Log("New target set with " + target.position.ToString());
        if (target != null)
            mover.SetTarget(target);
    }

    public void OnCloseToTarget()
    {
        Transform newTarget = router.GetNextWaypoint();
        mover.SetTarget(newTarget);
    }

    public void OnPathEnd()
    {
        PlayerStats.DecrementLives();
        if (status != null)
            PlayerStats.SurvivedRounds = status.waveNumber;

        Destroy(gameObject);
    }
}