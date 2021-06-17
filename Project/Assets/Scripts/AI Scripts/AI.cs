using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    public bool chasePlayer;
    public bool isAGuard;
    public bool isAZombie;

    public string checkpointName;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Idle(this.gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        currentState.isChaser = chasePlayer;
        currentState.isGuard = isAGuard;
        currentState.isZombie = isAZombie;

    }
}
