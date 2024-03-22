using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour
{

    public Transform[] targetPoint;
    public int currentPoint;

    public NavMeshAgent agent;

    public Animator Animator;

    public float waitAtPoint = 1f;
    private float waitCounter;

    public float distanceToPlayer;

    public enum AIState 
    {
        isDead , isSeekTargetPoint , isSeekPlayer , isAttack
    }
    public AIState state;   

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {
         distanceToPlayer = Vector3.Distance(transform.position, PlayerCon.instance.transform.position);


        if (!PlayerCon.instance.isDead) { 
            if (distanceToPlayer >= 15f && distanceToPlayer <= 50f)
            {
                state = AIState.isSeekPlayer;
            }
            else if (distanceToPlayer > 50f)
            {
                state = AIState.isSeekTargetPoint;

            }
                else
            { 
                state = AIState.isAttack; 
            }

            }
        else 
        {
            state = AIState.isSeekTargetPoint;
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);
        }

        switch (state)
        {
            case AIState.isDead:

                break;

            case AIState.isSeekPlayer:

                agent.SetDestination(PlayerCon.instance.transform.position);
                Animator.SetBool("Run", true);
                Animator.SetBool("Attack", false);
                break;

            case AIState.isSeekTargetPoint:

                agent.SetDestination(targetPoint[currentPoint].position);
                agent.stoppingDistance = 0f;

                if (agent.remainingDistance <= .2f)
                {
                    if (waitCounter > 0)
                    {
                        waitCounter -= Time.deltaTime;
                        Animator.SetBool("Run", false);
                    }
                    else
                    {
                        currentPoint++;
                        waitCounter = waitAtPoint;
                        Animator.SetBool("Run", true);
                    }


                    if (currentPoint >= targetPoint.Length)
                    {
                        currentPoint = 0;
                    }
                    agent.SetDestination(targetPoint[currentPoint].position);

                }

                break;

            case AIState.isAttack:
         
                agent.stoppingDistance = 1.5f;
                Animator.SetBool("Attack", true);
                Animator.SetBool("Run", false);
                break;

        }
    }
}
