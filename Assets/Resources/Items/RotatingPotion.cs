using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for rotating health potions
 */
public class RotatingPotion : MonoBehaviour {
    
    /**
     * Rotates health potion
     */
    void Update() {
        transform.Rotate(0, 1, 0);
    }
}
