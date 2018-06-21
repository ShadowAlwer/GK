using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for rotating gold coins
 */
public class RotatingGold : MonoBehaviour {

	/**
     * Rotates gold coin
     */
	void Update() {
        transform.Rotate(1, 0, 0);
	}
}
