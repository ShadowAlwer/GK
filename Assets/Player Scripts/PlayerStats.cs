using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Controls player statistics and updates GUI
 */
public class PlayerStats : MonoBehaviour {

    /**
     * Amount of hitpoints
     */
    public int hitpoints;

    /**
     * Reference to hp UI
     */
    public Text hpGUI;

    /**
     * Reference to particle effect for blood
     */
    public GameObject bloodPrefab;

    /// Reference to menu that appears after death.
    public GameObject gameLostUI;

    /// Text presenting final collected gold.
    public Text coinLostUI;

    /**
     * Reference to gold UI
     */
    public GameObject goldText;

    /**
     * Adds hp after drinking potion
     */
    public void addPotionValue(int hp)
    {
        hitpoints= (hitpoints+hp)>10 ? 10: hitpoints+hp;
    }

	/**
     * Updates hp value on GUI
     */
	void Update () {
        hpGUI.text = "HP: " + hitpoints;
	}


    /**
     * Called by enemy attacks
     * Decrease player hit points
     * Creates short living blood effect
     * Enables menu after players death.
     */
    public void TakeDamage(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0) {
            GameManager gm = FindObjectOfType<GameManager>();
            coinLostUI.text = "Collected: " + gm.currentGold + " gold!";
            goldText.SetActive(false);
            hpGUI.enabled = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in enemies) {
                i.SetActive(false);
            }
            gameLostUI.SetActive(true);
            FindObjectOfType<GameManager>().currentCameraState = false;
        } else {
            var blood=Instantiate(bloodPrefab, transform);
            Destroy(blood, 0.5f);
        }
    }

}
