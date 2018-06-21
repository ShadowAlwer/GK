using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class which rotate gold object.
*/
public class RotatingGold : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/**
	* In this method we update position of our gold coin.
	* We use rotate to change position.
	*/
	void Update () {
        transform.Rotate(1, 0, 0);
	}
}
