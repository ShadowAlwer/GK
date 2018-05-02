using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour { 
    public List<Weapon> inv_weapon;
    public List<Potion> inv_potion;
    public List<Item> inv_other;

	void Start()
	{
        // AddToInventory(new Weapon("matek knife5", "basic poor weapon", false, 100, "items/dagger", 1, 5, new Vector3(0, 0, 0), new Vector3(0, 0, 0)));
        // AddToInventory(new Weapon(" knife weak 2", "basic poor weapon", false, 100, "items/dagger", 1, 2, new Vector3(0, 0, 0), new Vector3(0, 0, 0)));
        // AddToInventory(new Weapon("matek knife20", "basic poor weapon", false, 100, "items/dagger", 1, 20, new Vector3(0, 0, 0), new Vector3(0, 0, 0)));
        // AddToInventory(new Weapon(" knife strong25", "basic poor weapon", false, 100, "items/dagger", 1, 25, new Vector3(0, 0, 0), new Vector3(0, 0, 0)));

        // AddToInventory(new Potion("potion of healing5", "basic poor healing potion", false, 30, "items/dagger", 5, 5));
        // AddToInventory(new Potion("potion of healing4", "basic poor healing potion", false, 30, "items/dagger", 5, 4));
        // AddToInventory(new Potion("healing5", "basic poor healing potion", false, 30, "items/dagger", 5, 5));
        // AddToInventory(new Potion("healing 25", "basic poor healing potion", false, 30, "items/dagger", 25, 25));
        // AddToInventory(new Potion("healing 24", "basic poor healing potion", false, 30, "items/dagger", 24, 24));
        // AddToInventory(new Potion("healing 35", "basic poor healing potion", false, 30, "items/dagger", 35, 35));
        // AddToInventory(new Potion("healing 34", "basic poor healing potion", false, 30, "items/dagger", 34, 34));
        // AddToInventory(new Potion("healing 15", "basic poor healing potion", false, 30, "items/dagger", 15, 15));
        // AddToInventory(new Potion("healing 16", "basic poor healing potion", false, 30, "items/dagger", 16, 16));

        saveInventory();
        inv_weapon.Sort();
        inv_potion.Sort();
        inv_other.Sort();
        //   loadInventory();
    }	

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
                Debug.Log("save");
                saveInventory();
        }
    }
	 public void saveInventory ()
    {
        InventoryData inventory_data = new InventoryData();
        inventory_data.weapon_data = inv_weapon;
        inventory_data.potion_data = inv_potion;
        inventory_data.other_data = inv_other;
        IOM.save<InventoryData>(inventory_data, "player_inventory");
        Debug.Log("inventory was saved");
    }
    public void loadInventory ()
    {
        if (IOM.fileExists("player_inventory"))
        {
            InventoryData id = IOM.load<InventoryData>("player_inventory");
            inv_weapon = id.weapon_data;
            inv_potion = id.potion_data;
            inv_other = id.other_data;
            Debug.Log("inventory was loaded");
        }
        else
            Debug.Log("inventory was'n loaded, because there is no file");    
    }
    public void AddToInventory(Item it)
    {
        if (it is Weapon)
        {
            inv_weapon.Add((Weapon)it);
            inv_weapon.Sort();
        }
        else if (it is Potion)
        {
            inv_potion.Add((Potion)it);
            inv_potion.Sort();
        }
        else
        {
            inv_other.Add(it);
            inv_other.Sort();
        }
    }
}
