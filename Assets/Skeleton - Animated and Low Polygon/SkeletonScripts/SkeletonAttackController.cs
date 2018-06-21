using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls behaviour of skeletons attacks
 */
public class SkeletonAttackController : MonoBehaviour {

    /**
     * Amount of damage that attack make
     */
    public int damage;

    /**
     * Determines if object is projectile (spell)
     */
    public bool isProjectile;
    

	// Use this for initialization
	void Start () {	}
	
    /**
	* Update is called once per frame and adds force to object if it has Rigidbody component (is spell)
    */
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 50);      
    }

    /**
     * Resolves collisions
     * If collision is with Player deals damage to it
     * If spell hits something that isn't skeleton spell will be destroyed
     */
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "Player") {

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        if (isProjectile && collision.gameObject.tag!="Enemy")
        {
            Debug.Log("Fireball Destroyed");
            Destroy(gameObject,0.15f);
        }

    }

    
}
