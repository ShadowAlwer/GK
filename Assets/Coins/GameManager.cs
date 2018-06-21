using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Class which is used to manage game.
*/
public class GameManager : MonoBehaviour {

	/**
	* Field which holds current gold value.
	*/
    public int currentGold;
	/**
	* Field which is used to show text on screen with current gold value.
	*/
    public Text goldText;	
	/**
	* Field which holds current camera state.
	*/
    public bool currentCameraState = true;
	/**
	* Field which holds text which is shown when player doesn't have
	* enough gold when tries to pass wall.
	*/
    public Text goldRequiredText;
	/**
	* Field which holds menu UI.
	*/
    public GameObject gameMenuUI;
	/**
	* Field which holds camera state.
	*/
    bool active = false;
    // Use this for initialization
    void Start () {
//        goldRequiredText.enabled = false;
    }

	// Update is called once per frame
	/**
	* Update method holds state if player want to quit game.
	* If he press ESC then camera freezes and menu UI i shown.
	*/
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            currentCameraState = active;
            active = !active;
            gameMenuUI.SetActive(active);
        }
	}
	/**
	* Method which is used to add gold when player pick up gold object.
	* We need also to change text on screen.
	*/
    public void AddGold(int goldValue)
    {
        currentGold += goldValue;
        goldText.text = "Gold: " + currentGold;
    }
}
