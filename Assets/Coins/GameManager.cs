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

	/// Reference to menu to activate.
    public GameObject gameMenuUI;

	/// Is menu active.
    private bool active = false;

	/// Shows main menu when user presses escape button.
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
