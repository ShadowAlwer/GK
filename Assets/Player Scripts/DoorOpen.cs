using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class which is used to open door between levels.
*/
public class DoorOpen : MonoBehaviour {

	/**
	* Fields which holds object to transform.
	*/
    public Transform door;
	/**
	* Field which is used to check gold require.
	*/
    public int goldRequired;
	/**
	* Vector which is used to change position of door. (closed)
	*/
    public Vector3 closedPosition = new Vector3(.51f, 3.63f, 0);
	/**
	* Vector which is used to change position of door. (opened)
	*/
    public Vector3 openPosition = new Vector3(.51f, 7, 0);
	/**
	* Field which holds open speed of door.
	*/
    public float openSpeed = 5;
	/**
	* Field which holds if doors are opened or closed.
	*/
    private bool open = false;

	
	// Update is called once per frame
	/**
	* Method which supports door open/close
	*/
	void Update () {

        if (open && FindObjectOfType<GameManager>().currentGold >= goldRequired)
        {
            door.position = Vector3.Lerp(door.position, openPosition, Time.deltaTime * openSpeed);
        }
        else {
            door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * openSpeed);
        }
	}
	/**
	* Method which check if there is collision with player.
	*/
    private void OnTriggerEnter(Collider other)
    {
        if (FindObjectOfType<GameManager>().currentGold < goldRequired)
       {
           FindObjectOfType<GameManager>().goldRequiredText.text = "Gold required: " + goldRequired;
           FindObjectOfType<GameManager>().goldRequiredText.enabled = true;
       }

        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }
	/**
	* Method which is called when player exit collider zone.
	*/
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
            FindObjectOfType<GameManager>().goldRequiredText.enabled = false;
        }
    }
	/**
	* Method which changes door state.
	*/
    public void CloseDoor()
    {
        open = false;
    }
	/**
	* Method which changes door state.
	*/
    public void OpenDoor()
    {
        open = true;
    }

}
