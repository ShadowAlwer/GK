using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class which is used to check if there is collision with object tagged "Player".
*/
public class GoldPickup : MonoBehaviour {

	/**
	*  Field whihch holds value of gold. (in example gold value can be 1,2 or 5, but could be higher)
	*/
    public int gold;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	* Method which check if there is collision.
	* If there is collision, we increment actual gold status
	* And destroy picked object.
	*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddGold(gold);

            Destroy(gameObject);
        }
    }


}
