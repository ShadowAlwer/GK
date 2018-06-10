using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall2 : MonoBehaviour {

    private int durability = 4;

    public void TakeDamage (int damage) {
        durability -= damage;
        if (durability == 2) {
            GetComponent<Animator>().Play("scale_ice_wall2");
        } else if (durability <= 0) {
            GetComponent<Animator>().Play("ice_wall2");
            
        }
    }
}
