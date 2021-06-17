using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PURSUE;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        if (isGuard)
        {
            anim.SetTrigger("isRunning");
            base.Enter();
        }
        else if (isZombie) 
        {
            anim.SetFloat("speed", 0.2f);
            base.Enter();
        }
    }

    public override void Update()
    {
        agent.SetDestination(player.position);
        if (agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                if (isChaser)
                {
                    if (isInFront()) 
                    {
                        nextState = new Attack(npc, agent, anim, player);
                        stage = EVENT.EXIT;
                    }
                    
                    
                }
                else if (!isChaser)
                {
                    nextState = new Attack(npc, agent, anim, player);
                    stage = EVENT.EXIT;
                }
            }
            else if (!CanSeePlayer())
            {
                nextState = new Patrol(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        if (isGuard)
        {
            anim.ResetTrigger("isRunning");
            base.Exit();
        }
        else if (isZombie)
        {
            anim.SetFloat("speed", 0.2f);
            base.Exit();
        }
    }
}
