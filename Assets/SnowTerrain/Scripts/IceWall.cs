using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (SnowMapSkeletonCounter.count <= 0)
        {
            GetComponent<Animator>().Play("ice_wall");
        }
	}
}
