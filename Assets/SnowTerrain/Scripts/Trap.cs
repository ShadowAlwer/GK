using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Go());
	}

    IEnumerator Go() {
        while(true){
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }
}
