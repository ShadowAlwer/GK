using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
* Class which is description about items.
*/
[System.Serializable]
public class Item: IComparable<Item>
{
	/**
	* Field which holds description of item.
	*/
    public string description;
	/**
	* Field which holds name of item
	*/
	public string name;
	/**
	* Field which holds value of item.
	*/
	public int value;
	/**
	* Field which holds if item is stackable
	*/
	public bool stackable;
	/**
	* Field which holds path model.
	*/
	public string modelPath;
	/**
	* Field which holds weight of item.
	*/
	public int weight;
	/**
	* Constructor which initialize all fields.
	*/
	public Item(string name,string description,bool stackable, int value, string modelPath, int weight)
	{
		this.description=description;
		this.name=name;
		this.stackable=stackable;
		this.value=value;
		this.modelPath=modelPath;
		this.weight=weight;
	}
	/**
	* Method which is used to compare items (used to sort)
	*/
    public int CompareTo(Item other)
    {
        return String.Compare(name, other.name); // a < aa < b
    }
}
/**
* Class which describes weapon. Inherits everything from item class.
*/
[System.Serializable]
public class Weapon: Item , IComparable <Weapon>
{
	/**
	* Field which holds weapon damage.
	*/
	public int damage;
	/**
	* Field which holds vector to rotate when weapon is on the ground.
	*/
	public Vector3 rotation;
	/**
	* Field which holds position.
	*/
	public Vector3 position;

	/**
	* Constructor with initialization
	*/
	public Weapon(string name,string description,bool stackable, int value,string modelPath,int weight,int damage, Vector3 position, Vector3 rotation)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.rotation=rotation;
		this.position=position;
		this.damage=damage;
	}
	/**
	* Method which is used to compare weapons (to sort in inventory)
	*/
    public int CompareTo(Weapon other)
    {
        if (damage == other.damage)
            return String.Compare(name, other.name); // a < aa < b
        return other.damage - damage;
    }
}
/**
* Class which describes potion. Inherits everything from item class.
*/
[System.Serializable]
public class Potion: Item, IComparable<Potion>
{
	/**
	* Field which holds how much health potion gives.
	*/
	public int healValue;
	/**
	* Constructor with initialization
	*/
	public Potion(string name,string description,bool stackable, int value,string modelPath,int weight,int healValue)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.healValue=healValue;
	}
	/**
	* Method which is used to compare potions (to sort in inventory)
	*/
    public int CompareTo(Potion other)
    {
        if (healValue == other.healValue)
            return String.Compare(name, other.name); // a < aa < b
        return other.healValue - healValue;
    }
}
/**
* Class which describes armor. Inherits everything from item class.
*/
[System.Serializable]
public class Armor: Item, IComparable<Armor>
{
	/**
	* Field which holds how much defense armor has.
	*/
	public int defense;
	/**
	* Constructor with initialization
	*/
	public Armor(string name,string description,bool stackable, int value,string modelPath,int weight,int defense)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.defense=defense;
	}
	/**
	* Method which is used to compare armors (to sort in inventory)
	*/
    public int CompareTo(Armor other)
    {
        return String.Compare(name, other.name); // a < aa < b
    }
}
/**
* Class which holds lists of inventory (all data)
*/
[System.Serializable]
public class InventoryData
{
	/**
	* List of items.
	*/
	public List<Item> other_data;
	/**
	* List of weapons.
	*/
    public List<Weapon> weapon_data;
	/**
	* List of potions.
	*/
    public List<Potion> potion_data;
}
