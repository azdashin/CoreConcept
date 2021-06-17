using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL;
        agent.speed = 1;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < GameEnvironment.Singleton.Checkpoints.Count; i++)
        {
            GameObject thisWP = GameEnvironment.Singleton.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            if (distance < lastDist)
            {
                currentIndex = i - 1;
                lastDist = distance;
            }
        }
        
        if (isGuard) 
        {
            anim.SetTrigger("isWalking");
            base.Enter();
        }
        
        else if(isZombie)
        {
            anim.SetTrigger("walk");
            base.Enter();
        }
        
    }

    public override void Update()
    {
        
        if (agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            agent.SetDestination(GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
        }
        
        /*
        if (agent.remainingDistance < 1)
        {
            if (currentIndex >= aivalue.checkpoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            agent.SetDestination(aivalue.checkpoints[0].transform.position);
        }
        */
        
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

        else if (IsPlayerBehind())
        {
            nextState = new RunAway(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

        Debug.Log("Patrolling");
    }

    public override void Exit()
    {
        if (isGuard)
        {
            anim.ResetTrigger("isWalking");
            base.Exit();
        }
        else if (isZombie)
        {
            anim.ResetTrigger("walk");
            base.Exit();
        }
    }
}
