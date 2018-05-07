using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	// Use this for initialization
	GameObject helperPanel;
	void Awake () {
		helperPanel=GameObject.FindGameObjectWithTag("Helper");
        helperPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
