using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class which is responsible for opening inventory
*/
public class InventoryOpening : MonoBehaviour {

	/**
	* Field which holds current inventory state.
	*/
	public bool opened=false;
	/**
	* Field which holds inventory panel.
	*/
	private GameObject inventoryPanel;
	/**
	* Field which holds current picked sword.
	*/
	private GameObject swordInitiated;
	/**
	* Field which holds weapon.
	*/
	GameObject WeaponEnd;
	/**
	* Field which holds inventory menu.
	*/
	InventoryMenu inventoryMenu;
	/**
	* Field which was used for tests.
	*/
	int i=0;
	/**
	* Method which initialize inventory.
	*/
	void Awake()
	{
		
		inventoryPanel=GameObject.FindGameObjectWithTag("inventory");
		inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
		opened=false;
		inventoryPanel.SetActive(false);
		
	}
	/**
	* Method which check if inventory is opened or closed.
	*/
	void Update () {

		if (Input.GetKey (KeyCode.I) && opened==false )
        {
            FindObjectOfType<GameManager>().currentCameraState = false;

            opened=true;
		//	Debug.Log("otwieram inventory " +i++);
			inventoryPanel.SetActive(true);
			inventoryMenu.updateInventory();
			
			
        }
		if (Input.GetKey (KeyCode.O) && opened==true)
        {
            FindObjectOfType<GameManager>().currentCameraState = true;
            //WeaponEnd.transform.parent=sword2.transform;
            //WeaponEnd.transform.parent = sword2.;

            opened =false;
			//Debug.Log("zamykam inventory " +i++);
			inventoryPanel.SetActive(false);
		
        }
		
	}
	
}
