using UnityEngine;

public class PortalScript : MonoBehaviour {

    public Transform player;
    public Vector3 teleportTo;

    void OnCollisionEnter(Collision info) {
        if (info.collider.tag == "Player") {
            player.position = teleportTo;
        }
    }
}
