using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class reponsible for lava on second terrain
 */
public class LavaScript : MonoBehaviour {

    /**
     * Last time, when player got hit by lava
     */
    private float damageInterval;

    /**
     * Takes player health points at enter into lava
     */
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
            damageInterval = Time.time;
        }
    }

    /**
     * Takes player health points while staying in lava
     */
    private void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            if (damageInterval <= Time.time - 1) {
                collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
                damageInterval = Time.time;
            }
        }
    }
}
