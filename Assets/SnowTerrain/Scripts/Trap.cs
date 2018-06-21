using System.Collections;
using UnityEngine;

/**
 * Class responsible for ice spikes on third terrain
 */
public class Trap : MonoBehaviour {

	/**
     * Start Coroutine for ice spikes appears
     */
	void Start () {
        StartCoroutine(Go());
	}

    /**
     * Coroutine responsible for ice spikes animation
     */
    IEnumerator Go() {
        while (true) {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }

    /**
     * Takes player health points at enter on ice spike
     */
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }
}
