using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
/**
* Class which is used to move platforms.
*/
public class MovingPlatform : MonoBehaviour {
	/**
	* Field which holds platform.
	*/
    public Transform movingPlatform;
	/**
	* Field which holds first position of platform.
	*/
    public Transform position1;
	/**
	* Field which holds second position of platform.
	*/
    public Transform position2;
	/**
	* Field which holds new position of platform.
	*/
    public Vector3 newPosition;
	/**
	* Field which holds current platform state.
	*/
    public string currentState;
	/**
	* Field which holds how smooth will platform move.
	*/
    public float smooth;
	/**
	* Field which holds how fast will platform move.
	*/
    public float resetTime;
    // Use this for initialization
	/**
	* Method which is used for initialization
	*/
    void Start () {
        ChangeTarget();
	}
	/**
	* Method which change platform position.
	*/
    private void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }
	/**
	* Method which change target of platform.
	*/
    void ChangeTarget()
    {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
