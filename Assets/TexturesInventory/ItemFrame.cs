using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* Class which holds information about item frame.
*/
public class ItemFrame : MonoBehaviour {

	/**
	* Field which holds name of item.
	*/
	public string name;
	/**
	* Field which holds value of item.
	*/
    public int value;
	/**
	* Field which holds text to show in game.
	*/
    public Text nameTxt, valueTxt;
	/**
	* Field which holds item.
	*/
    public Item item;
    int i=0;
   
   /**
	* Constructor which set text values.
	*/
    public void setValues ()
    {
        nameTxt.text = name;
        valueTxt.text = value.ToString();
    }
	/**
	* Method which changes current weapon.
	*/
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
	/**
	* Method which is used to change color of item frame.
	*/
    public void changeColor(Color color)
	{

		color.a=1;
		Image frameImage=gameObject.GetComponent<Image>();
        frameImage.color=color;
	}
	/**
	* Method which is used to disable item frame.
	*/
    public void disableFrame()
    {
         InventoryMenu inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
         inventoryMenu.disableFrame();
    }
    

}
