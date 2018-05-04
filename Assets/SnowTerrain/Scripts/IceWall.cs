using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour {

    int enemiesLeft = 0;

	// Use this for initialization
	void Start () {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemiesLeft++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (enemiesLeft <= 0)
        {
            GetComponent<Animator>().Play("ice_wall");
        }
	}
}
