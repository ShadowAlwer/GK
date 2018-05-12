using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int hitpoints;
    public Text hpGUI;
    public GameObject bloodPrefab;
    public GameObject gameLostUI;
    public Text coinLostUI;
    public GameObject goldText;

	// Use this for initialization
	void Start () {
    }
    public void addPotionValue(int hp)
    {
        hitpoints= (hitpoints+hp)>10 ? 10: hitpoints+hp;
    }

	// Update is called once per frame
	void Update () {
        hpGUI.text = "HP: " + hitpoints;
	}

    public void TakeDamage(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0) {
            GameManager gm = FindObjectOfType<GameManager>();
            coinLostUI.text = "Collected: " + gm.currentGold + " gold!";
            goldText.SetActive(false);
            hpGUI.enabled = false;
            gameLostUI.SetActive(true);
        } else {
            var blood=Instantiate(bloodPrefab, transform);
            Destroy(blood, 0.5f);
        }
    }

}
