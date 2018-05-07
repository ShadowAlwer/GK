using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour {

	public string name;
    public int value;
    public Text nameTxt, valueTxt;

    public Item item;
    int i=0;
   
    public void setValues ()
    {
        nameTxt.text = name;
        valueTxt.text = value.ToString();
    }
    public void setNewWeapon()
	{
        if (item is Weapon)
        {
            Player_weapons playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_weapons>();
            playerWeapons.setNewWeapon((Weapon) item);
            disableFrame();
            changeColor(Color.cyan);
        }
        if (item is Potion)
        {
            Debug.Log("Wchodze w SetNewWeapon do potek "+i++);
            Potion potion=(Potion) item;
            PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            playerStats.addPotionValue(potion.healValue);
            InventoryMenu inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
            //disableFrame();
            //changeColor(Color.cyan);
            
            PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>() as PlayerInventory;
            playerInventory.removeFromInventory(item);
            GameObject.Destroy(gameObject);
            inventoryMenu.updateInventory();
        }
	}
    public void changeColor(Color color)
	{

		color.a=1;
		Image frameImage=gameObject.GetComponent<Image>();
        frameImage.color=color;
	}
    public void disableFrame()
    {
         InventoryMenu inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
         inventoryMenu.disableFrame();
    }
    

}
