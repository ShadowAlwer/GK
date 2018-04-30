using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;  // Detection range for player
    public float distance;
    public bool shouldMove;
    public bool shouldFight;
    public bool isMage;
    public float spellCastRate;
    public float spellCastDuration;
    float nextSpellCast;
    float nextMove;
    public float attackingDistance;

    public Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    Animator animator;   
    public Vector2 velocity;
    public GameObject fireball;
    public Transform spellPoint;
    

    // Use this for initialization
    void Start()
    {
       
        nextSpellCast = 0;
        shouldFight = false;
        shouldMove = false;       
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        if(!isMage)
        attackingDistance = agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        // Distance to the target
        distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius && nextMove <= time)
        {
            if (isMage && nextSpellCast <= time)
            {
                              
                    if(agent.hasPath)
                       agent.Stop();

                    FaceTarget();
                    shouldFight = true;
                    shouldMove = false;
                    animator.SetBool("magic", true);
                    animator.SetBool("move", shouldMove);
                    animator.SetBool("fight", shouldFight);
                    animator.SetFloat("vx", velocity.x);
                    animator.SetFloat("vy", velocity.y);
                    nextSpellCast = time + spellCastRate;
                    nextMove = time + spellCastDuration;
                    
                    GameObject spell=Instantiate(fireball);
                    spell.GetComponent<Transform>().position = spellPoint.transform.position;
                    Vector3 direction = (target.position - spellPoint.transform.position).normalized;                                       
                    spell.GetComponent<Transform>().rotation = spellPoint.transform.rotation;
                    spell.GetComponent<Transform>().Rotate(0,-90,0);

            }
            else
            {
                if (agent.isStopped)
                    agent.Resume();
                // Move towards the target
                agent.SetDestination(target.position);
                velocity.y = 0.9f;
                shouldMove = true;
                shouldFight = false;
                // Update animation parameters

                // If within attacking distance
                if (distance <= agent.stoppingDistance)
                {
                    if(distance<attackingDistance)
                    shouldFight = true;
                    shouldMove = false;
                    FaceTarget();   // Make sure to face towards the target
                }
                // Update animation parameters
                animator.SetBool("move", shouldMove);
                animator.SetBool("fight", shouldFight);
                animator.SetFloat("vx", velocity.x);
                animator.SetFloat("vy", velocity.y);
                animator.SetBool("magic", false);


            }
            if (distance > lookRadius && shouldMove == true)
            {
                if (agent.hasPath)
                    agent.ResetPath();
                shouldMove = false;
                animator.SetBool("move", shouldMove);
            }
        }
    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}