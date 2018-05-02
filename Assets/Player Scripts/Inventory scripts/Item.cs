using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Item: IComparable<Item>
{

    public string description;
	public string name;
	public int value;
	public bool stackable;
	public string modelPath;
	public int weight;
	public Item(string name,string description,bool stackable, int value, string modelPath, int weight)
	{
		this.description=description;
		this.name=name;
		this.stackable=stackable;
		this.value=value;
		this.modelPath=modelPath;
		this.weight=weight;
	}

    public int CompareTo(Item other)
    {
        return String.Compare(name, other.name); // a < aa < b
    }
}
[System.Serializable]
public class Weapon: Item , IComparable <Weapon>
{
	public int damage;
	public Vector3 rotation;
	public Vector3 position;

	public Weapon(string name,string description,bool stackable, int value,string modelPath,int weight,int damage, Vector3 position, Vector3 rotation)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.rotation=rotation;
		this.position=position;
		this.damage=damage;
	}

    public int CompareTo(Weapon other)
    {
        if (damage == other.damage)
            return String.Compare(name, other.name); // a < aa < b
        return other.damage - damage;
    }
}
[System.Serializable]
public class Potion: Item, IComparable<Potion>
{
	public int healValue;
	public Potion(string name,string description,bool stackable, int value,string modelPath,int weight,int healValue)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.healValue=healValue;
	}

    public int CompareTo(Potion other)
    {
        if (healValue == other.healValue)
            return String.Compare(name, other.name); // a < aa < b
        return other.healValue - healValue;
    }
}
[System.Serializable]
public class Armor: Item, IComparable<Armor>
{
	public int defense;
	public Armor(string name,string description,bool stackable, int value,string modelPath,int weight,int defense)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.defense=defense;
	}

    public int CompareTo(Armor other)
    {
        return String.Compare(name, other.name); // a < aa < b
    }
}
[System.Serializable]
public class InventoryData
{
	public List<Item> other_data;
    public List<Weapon> weapon_data;
    public List<Potion> potion_data;
}
