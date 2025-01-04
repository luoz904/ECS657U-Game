using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGoblinAnimator : MonoBehaviour
{

	public bool isControlEnabled = false;
	private Animator anim;
	
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	enum AnimationState
	{
		None,
		BattleIdle,
		Idle,
		Walk,
		Run,
		DefenseStart1,
		DefenseStart2,
		DefenseEnd,
		Attack1,
		Attack2,
		Attack3,
		Jump,
		Die1,
		Die2,
		Defense1,
		Defense2
	}

	void SetAnimationCommand(string cmd, int value)
	{
		anim.SetInteger(cmd, value);
	}

	void SetAnimationState(AnimationState state)
	{
		switch (state)
		{
			case AnimationState.Idle:
				SetAnimationCommand("battle", 0);
				break;
			case AnimationState.BattleIdle:
				SetAnimationCommand("battle", 1);
				break;
			case AnimationState.Walk:
				SetAnimationCommand("moving", 1);
				break;
			case AnimationState.Run:
				SetAnimationCommand("moving", 2);
				break;
			case AnimationState.DefenseStart1:
				SetAnimationCommand("moving", 6);
				break;
			case AnimationState.DefenseStart2:
				SetAnimationCommand("moving", 8);
				break;
			case AnimationState.DefenseEnd:
				SetAnimationCommand("moving", 9);
				break;
			case AnimationState.Attack1:
				SetAnimationCommand("moving", 3);
				break;
			case AnimationState.Attack2:
				SetAnimationCommand("moving", 4);
				break;
			case AnimationState.Attack3:
				SetAnimationCommand("moving", 5);
				break;
			case AnimationState.Jump:
				SetAnimationCommand("moving", 7);
				break;
			case AnimationState.Die1:
				SetAnimationCommand("moving", 12);
				break;
			case AnimationState.Die2:
				SetAnimationCommand("moving", 13);
				break;
			case AnimationState.Defense1:
				SetAnimationCommand("moving", 10);
				break;
			case AnimationState.Defense2:
				SetAnimationCommand("moving", 11);
				break;
			default:
				break;
		}
	}

	private AnimationState MapInpuToAnimationState()
	{
		bool battleMode = false;
		AnimationState state = AnimationState.None;

		if (Input.GetKey("2")) //battle_idle
		{
			state = AnimationState.BattleIdle;
			battleMode = true;
		}
		if (Input.GetKey("1")) //idle
		{
			state = AnimationState.Idle;
			battleMode = false;
		}
		if (Input.GetKey("up"))
		{
			//moving
			if (battleMode == false)
			{
				state = AnimationState.Walk;
				//walk
				//runSpeed = 1.0f;
			}
			else
			{
				state = AnimationState.Run;
				//run
				//runSpeed = 2.6f;
			}
		}
		else
		{
			state = AnimationState.Idle;
		}

		if (Input.GetKeyDown("m")) //defence_start
		{
			state = AnimationState.DefenseStart1;

		}

		if (Input.GetKeyDown("p")) // defence_start
		{
			state = AnimationState.DefenseStart2;
		}
		if (Input.GetKeyUp("p")) // defence_end
		{
			state = AnimationState.DefenseEnd;
		}

		if (Input.GetMouseButtonDown(0)) //attack
		{
			state = AnimationState.Attack1;
		}
		if (Input.GetMouseButtonDown(1)) //alt attack1
		{
			state = AnimationState.Attack2;

		}
		if (Input.GetMouseButtonDown(2)) //alt attack2
		{
			state = AnimationState.Attack3;
		}

		if (Input.GetKeyDown("space")) //jump
		{
			state = AnimationState.Jump;
		}


		if (Input.GetKeyDown("o")) //die_1
		{
			state = AnimationState.Die1;
		}
		if (Input.GetKeyDown("i")) //die_2
		{
			state = AnimationState.Die2;
		}

		if (Input.GetKeyDown("u")) //defence
		{
			int n = Random.Range(0, 2);
			if (n == 0)
			{
				state = AnimationState.Defense1;
			}
			else
			{
				state = AnimationState.Defense2;
			}
		}
		return state;
	}

	// Update is called once per frame
	void Update()
	{
		if (isControlEnabled)
		{
			AnimationState state = MapInpuToAnimationState();
			SetAnimationState(state);
		}
	}
}

