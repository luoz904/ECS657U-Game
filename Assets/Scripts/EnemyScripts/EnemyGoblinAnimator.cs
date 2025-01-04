using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGoblinAnimator : MonoBehaviour
{

	public bool isControlEnabled = false;
	private Animator anim;

	// Use this for initialization
	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	void SetAnimationCommand(string cmd, int value)
	{
		anim.SetInteger(cmd, value);
	}

	public void SetAnimationState(EnemyState state)
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

	private EnemyState MapInpuToAnimationState()
	{
		bool battleMode = false;
		EnemyState state = EnemyState.None;

		if (Input.GetKey("2")) //battle_idle
		{
			state = EnemyState.BattleIdle;
			battleMode = true;
		}
		if (Input.GetKey("1")) //idle
		{
			state = EnemyState.Idle;
			battleMode = false;
		}
		if (Input.GetKey("up"))
		{
			//moving
			if (battleMode == false)
			{
				state = EnemyState.Walk;
				//walk
				//runSpeed = 1.0f;
			}
			else
			{
				state = EnemyState.Run;
				//run
				//runSpeed = 2.6f;
			}
		}
		else
		{
			state = EnemyState.Idle;
		}

		if (Input.GetKeyDown("m")) //defence_start
		{
			state = EnemyState.DefenseStart1;

		}

		if (Input.GetKeyDown("p")) // defence_start
		{
			state = EnemyState.DefenseStart2;
		}
		if (Input.GetKeyUp("p")) // defence_end
		{
			state = EnemyState.DefenseEnd;
		}

		if (Input.GetMouseButtonDown(0)) //attack
		{
			state = EnemyState.Attack1;
		}
		if (Input.GetMouseButtonDown(1)) //alt attack1
		{
			state = EnemyState.Attack2;

		}
		if (Input.GetMouseButtonDown(2)) //alt attack2
		{
			state = EnemyState.Attack3;
		}

		if (Input.GetKeyDown("space")) //jump
		{
			state = EnemyState.Jump;
		}


		if (Input.GetKeyDown("o")) //die_1
		{
			state = EnemyState.Die1;
		}
		if (Input.GetKeyDown("i")) //die_2
		{
			state = EnemyState.Die2;
		}

		if (Input.GetKeyDown("u")) //defence
		{
			int n = Random.Range(0, 2);
			if (n == 0)
			{
				state = EnemyState.Defense1;
			}
			else
			{
				state = EnemyState.Defense2;
			}
		}
		return state;
	}

	// Update is called once per frame
	void Update()
	{
		if (isControlEnabled)
		{
			EnemyState state = MapInpuToAnimationState();
			SetAnimationState(state);
		}
	}
}

