using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/** 
 * Controls the Enemy AI 
 */

public class EnemyController : MonoBehaviour
{

    /**
     * Detection range for enemy
     */
    public float lookRadius = 10f;

    /**
     * Distance from player
     */
    public float distance;

    /**
     * Determines if enemy should move
     */
    public bool shouldMove;

    /**
     * Determines if enemy should fight
     */
    public bool shouldFight;

    /**
    * Determines if enemy is mage
    */
    public bool isMage;

    /**
    * Minimal time between spell casts
    */
    public float spellCastRate;

    /**
    * Duration of spell cast animation
    */
    public float spellCastDuration;

    /**
    * Time of next spell cast
    */
    float nextSpellCast;

    /**
    * Time of next move
    */
    float nextMove;

    /**
    * Attacking distance of enemy
    */
    public float attackingDistance;

    /**
    * Reference to the player
    */
    public Transform target;

    /**
    * Reference to the NavMeshAgent
    */
    NavMeshAgent agent;

    /**
    * Reference to the Animator
    */
    Animator animator;

    /**
    *  Velocity of animation
    */
    public Vector2 velocity;

    /**
     * Reference to spell prefab
     */
    public GameObject fireball;

    /**
     * Transform of point from whitch spells are cast
     */
    public Transform spellPoint;
    

   /**
    * Inicialization of some variables
    */
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

    /**
     * Controls the behaviour of enemy AI
     */
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
                    Debug.Log("Fireball Created!");
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

    /*
     *Rotate to face the target
     */
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /*
     * Draws look radius sphere in Unity
     */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}