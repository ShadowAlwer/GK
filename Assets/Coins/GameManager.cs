using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentGold;
    public Text goldText;
    public bool currentCameraState = true;
    public Text goldRequiredText;
    public GameObject gameMenuUI;
    bool active = false;
    // Use this for initialization
    void Start () {
//        goldRequiredText.enabled = false;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            currentCameraState = active;
            active = !active;
            gameMenuUI.SetActive(active);
        }
	}

    public void AddGold(int goldValue)
    {
        currentGold += goldValue;
        goldText.text = "Gold: " + currentGold;
    }
}
