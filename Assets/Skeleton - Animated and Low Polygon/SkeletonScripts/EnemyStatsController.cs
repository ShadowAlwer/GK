using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls enemy statistics
 */
public class EnemyStatsController : MonoBehaviour {


    /**
     * Enemy hit points
     */
    public int health;

	
	/**
     * Checks if skeleton has died
     */
	void Update () {
        if (health <= 0)
        {
            Debug.Log("Skeleon died");
            SnowMapSkeletonCounter.count--;
            Destroy(gameObject);
        }
	}

    /**
     * Decrease enemy hit points
     */
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
