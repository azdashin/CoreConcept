using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        if (isGuard)
        {
            anim.SetTrigger("isIdle");
            base.Enter();
        }
        else if (isZombie) 
        {
            anim.SetTrigger("idle");
            base.Enter();
        }
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        
        else if (Random.Range(0, 5000) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        if (isGuard)
        {
            anim.ResetTrigger("isIdle");
            base.Exit();
        }
        else if (isZombie)
        {
            anim.ResetTrigger("idle");
            base.Exit();
        }
    }
}
