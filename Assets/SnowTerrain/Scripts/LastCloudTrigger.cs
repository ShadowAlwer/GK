using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCloudTrigger : MonoBehaviour {

    public GameObject endCamera;

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            endCamera.SetActive(true);
        }
    }
}
