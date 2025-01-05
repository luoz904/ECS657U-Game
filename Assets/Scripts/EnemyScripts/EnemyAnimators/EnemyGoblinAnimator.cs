using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGoblinAnimator : EnemyAnimator
{

	public override void SetAnimationState(EnemyState state)
	{
		switch (state)
		{
			case EnemyState.Idle:
				SetAnimationCommand("battle", 0);
				break;
			case EnemyState.BattleIdle:
				SetAnimationCommand("battle", 1);
				break;
			case EnemyState.Walk:
				SetAnimationCommand("moving", 1);
				break;
			case EnemyState.Run:
				SetAnimationCommand("moving", 2);
				break;
			case EnemyState.DefenseStart1:
				SetAnimationCommand("moving", 6);
				break;
			case EnemyState.DefenseStart2:
				SetAnimationCommand("moving", 8);
				break;
			case EnemyState.DefenseEnd:
				SetAnimationCommand("moving", 9);
				break;
			case EnemyState.Attack1:
				SetAnimationCommand("moving", 3);
				break;
			case EnemyState.Attack2:
				SetAnimationCommand("moving", 4);
				break;
			case EnemyState.Attack3:
				SetAnimationCommand("moving", 5);
				break;
			case EnemyState.Jump:
				SetAnimationCommand("moving", 7);
				break;
			case EnemyState.Die1:
				SetAnimationCommand("moving", 12);
				break;
			case EnemyState.Die2:
				SetAnimationCommand("moving", 13);
				break;
			case EnemyState.Defense1:
				SetAnimationCommand("moving", 10);
				break;
			case EnemyState.Defense2:
				SetAnimationCommand("moving", 11);
				break;
			default:
				break;
		}
	}

	void SetAnimationCommand(string cmd, int value)
	{
		anim.SetInteger(cmd, value);
	}
}

