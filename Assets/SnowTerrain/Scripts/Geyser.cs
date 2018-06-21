using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for geysers on third terrain
 */
public class Geyser : MonoBehaviour {

    /**
     * Geyser force flag
     */
    private bool isForceOn = false;

    /**
     * Start geyser activity repeating
     */
    void Start() {
        InvokeRepeating("Go", 0f, 5f);
        InvokeRepeating("Wait", 1f, 5f);
    }

    /**
     * Active geyser
     */
    void Go() {
        isForceOn = true;
        GetComponent<ParticleSystem>().Play();
    }

    /**
     * Inactive geyser
     */
    void Wait() {
        isForceOn = false;
    }

    /**
     * Adds force to player
     */
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && isForceOn)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1300, ForceMode.Impulse);
            isForceOn = false;
        }
    }
}
