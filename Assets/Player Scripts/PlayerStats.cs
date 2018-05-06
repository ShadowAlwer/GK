using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int hitpoints;
    public Text hpGUI;

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
    }

}

