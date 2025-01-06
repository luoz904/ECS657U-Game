using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseAnimator : MageAnimator
{

    public override void SetAnimationState(MageState state)
    {
        switch (state)
        {
            case MageState.Idle:
                anim.SetBool("Idle", true);
                break;
            case MageState.Attack:
                anim.SetBool("Idle", true);
                break;
            case MageState.Upgrade:
                anim.SetBool("Upgrade", true);
                break;
            default:
                break;
        }
    }
}