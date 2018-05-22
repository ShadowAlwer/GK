using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour {

    private bool isForceOn = false;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Go", 0f, 5f);
        InvokeRepeating("Wait", 1f, 5f);
    }

    void Go()
    {
        isForceOn = true;
        GetComponent<ParticleSystem>().Play();
    }

    void Wait()
    {
        isForceOn = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && isForceOn)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1300, ForceMode.Impulse);
            isForceOn = false;
        }
    }
}
