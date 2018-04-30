using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentGold;
    public Text goldText;
    public Text goldRequiredText;
	// Use this for initialization
	void Start () {
        goldRequiredText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddGold(int goldValue)
    {
        currentGold += goldValue;
        goldText.text = "Gold: " + currentGold;
    }
}
