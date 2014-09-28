using UnityEngine;
using System.Collections;

public class W_Shotgun_Test : MonoBehaviour {
	public int shotNumber;
	public float shotRadius;
	public GameObject shot;
	float angleStep, currentAngle, shotPosX, shotPosY;
	Vector3 shotPosition;
	Quaternion shotRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Mouse1)){
			angleStep = 180/(shotNumber+1);					//Find how much space there is between each shot
			currentAngle = transform.eulerAngles.z - 90;	//Set the leftmost point of the arc

			for(int i = 0; i < shotNumber; i++){
				currentAngle += angleStep;		//Move to the next shot trajectory
				shotPosX = (shotRadius * Mathf.Sin(currentAngle)) + transform.position.x;		//Find the position to spawn it at
				shotPosY = (shotRadius * Mathf.Cos(currentAngle)) + transform.position.y;
				shotPosition = new Vector3(shotPosX,shotPosY,0);
				shotRotation = Quaternion.Euler(0,0,-currentAngle + transform.eulerAngles.z);	//Find the angle to spawn it at
				Instantiate(shot, shotPosition, shotRotation);		//Spawn it at the right position and angle
			}
		}
	}
}
