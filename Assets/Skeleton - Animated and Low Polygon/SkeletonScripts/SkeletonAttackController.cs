using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackController : MonoBehaviour {

    public int damage;
    public bool isProjectile;
    

	// Use this for initialization
	void Start () {

        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right*1000);
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 50);
        

    }


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
