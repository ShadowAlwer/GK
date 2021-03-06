﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_weapons : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	bool equiped;
	GameObject currentWeaponGameObject;
	string nameOfCurrentWeapon;

	public GameObject getCurrentWeaponGameObject()
	{
		return currentWeaponGameObject;
	}
	public string getCurrentWeaponName()
	{
		return nameOfCurrentWeapon;
	}
	void Start () {
		 anim = GetComponent <Animator> ();
		 currentWeaponGameObject=null;
	}
	// Update is called once per frame
	void Update () {
		//currentWeaponGameObject.transform.position=new Vector3(100,100,100);
		if (Input.GetKey (KeyCode.Z))
        {
            if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idle")&& currentWeaponGameObject!=null)
            {
				anim.SetBool ("equipingWeapon",true);
				displayWeapon();
			}
            else if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idleWeap")&& currentWeaponGameObject!=null)
			{
				anim.SetBool ("hidingWeapon",true);
				hideWeapon();
			}
        }
		Debug.Log(Input.GetAxis ("Fire1"));
		if (Input.GetAxis ("Fire1")>0.1)
        {
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idleWeap")||anim.GetCurrentAnimatorStateInfo (0).IsTag ("walkingWeap"))
            anim.SetBool ("attackingWeapon",true);
        }
	}
	
	public void displayWeapon() {
		
	/*	if (weapons[currentWeapon]!=null)
			weapons[currentWeapon].SetActive(true);
		currentWeapon++;
		if(currentWeapon >= weapons.Length) {
			currentWeapon = 0;
		}	*/
		currentWeaponGameObject.SetActive(true);


		equiped=true;
	}
	public void hideWeapon()
	{
		/*if (weapons[currentWeapon]!=null)
			weapons[currentWeapon].SetActive(false);*/
		currentWeaponGameObject.SetActive(false);
		equiped=false;
	}

	public void setNewWeapon(Weapon weapon)
	{
		nameOfCurrentWeapon=weapon.name;
		Debug.Log("Probuje stworzyc item");
		GameObject WeaponEnd=GameObject.FindGameObjectWithTag("WeaponEnd");
		var weaponResource=Resources.Load(weapon.modelPath);
		
		var weaponGameObject= GameObject.Instantiate(weaponResource, WeaponEnd.transform.position, WeaponEnd.transform.rotation) as GameObject;
		weaponGameObject.transform.SetParent(WeaponEnd.transform);
		
		Rigidbody rg=weaponGameObject.GetComponent<Rigidbody>();
		rg.constraints= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY 
			| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		weaponGameObject.transform.localPosition=weapon.position;
		weaponGameObject.transform.localEulerAngles=weapon.rotation;
		GameObject.Destroy(currentWeaponGameObject);
		currentWeaponGameObject=weaponGameObject;
		
		
        currentWeaponGameObject.GetComponent<PlayerWeaponController>().damage = weapon.damage;
		if (equiped==true)
			currentWeaponGameObject.SetActive(true);
		else
			currentWeaponGameObject.SetActive(false);

		//Debug.Log("Damage");
		//Debug.Log("Damage"+weapon.damage);

	}

    


}
