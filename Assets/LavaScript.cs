using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    private float damageInterval;

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
            damageInterval = Time.time;
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            if (damageInterval <= Time.time - 1) {
                collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
                damageInterval = Time.time;
            }
        }
    }
}
