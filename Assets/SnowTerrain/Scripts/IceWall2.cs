using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for second ice wall on third terrain
 */
public class IceWall2 : MonoBehaviour {

    /**
     * Durability points of the ice wall
     */
    private int durability = 4;

    /**
     * Melts ice wall when get hit by torch
     */
    public void TakeDamage (int damage) {
        durability -= damage;
        if (durability == 2) {
            GetComponent<Animator>().Play("scale_ice_wall2");
        } else if (durability <= 0) {
            GetComponent<Animator>().Play("ice_wall2");
        }
    }
}
