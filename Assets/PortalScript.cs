using UnityEngine;

public class PortalScript : MonoBehaviour {

    public Vector3 teleportTo;

    void OnCollisionEnter(Collision info) {
        if (info.collider.tag == "Player") {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() as Transform;
            player.position = teleportTo;
        }
    }
}
