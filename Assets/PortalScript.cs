using UnityEngine;

/// Class containing logic of portals.
public class PortalScript : MonoBehaviour {

    /// Where is player to be teleported to when entering portal.
    public Vector3 teleportTo;

    /// Teleports player to the specified location.
    void OnCollisionEnter(Collision info) {
        if (info.collider.tag == "Player") {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() as Transform;
            player.position = teleportTo;
        }
    }
}
