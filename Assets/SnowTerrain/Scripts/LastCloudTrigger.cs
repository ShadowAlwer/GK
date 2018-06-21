using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class responsible for activating end cutscene script
 */
public class LastCloudTrigger : MonoBehaviour {

    /**
     * Reference to end camera
     */
    public GameObject endCamera;

    /**
     * Sets third camera as active
     */
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            endCamera.SetActive(true);
        }
    }
}
