using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for first ice wall on third terrain
 */
public class IceWall : MonoBehaviour {

	/**
     * Melts ice wall when skeletons are dead
     */
	void Update () {
		if (SnowMapSkeletonCounter.count <= 0) {
            GetComponent<Animator>().Play("ice_wall");
        }
	}
}
