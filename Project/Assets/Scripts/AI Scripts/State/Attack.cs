using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    float rotationSpeed = 2.0f;
    AudioSource shoot;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.ATTACK;
        shoot = npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        if (isGuard)
        {
            anim.SetTrigger("isShooting");
            agent.isStopped = true;
            shoot.Play();
            base.Enter();
        }
        else if (isZombie) 
        {
            anim.SetTrigger("attack");
            base.Enter();
        }
    }

    public override void Update()
    {
        if (isGuard)
        {
            Vector3 direction = player.position - npc.transform.position;
            float angle = Vector3.Angle(direction, npc.transform.forward);
            direction.y = 0;

            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            if (!CanAttackPlayer())
            {
                nextState = new Idle(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
        else if (isZombie) 
        {
            Vector3 direction = player.position - npc.transform.position;
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

            agent.SetDestination(player.position);
            anim.SetTrigger("attack");

            if (!CanAttackPlayer())
            {
                nextState = new Idle(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        if (isGuard)
        {
            anim.ResetTrigger("isShooting");
            shoot.Stop();
            base.Exit();
        }
        else if (isZombie) 
        {
            anim.ResetTrigger("attack");
            base.Exit();
        }
    }
}
