using UnityEngine;
using System.Collections;

public class C_Movement : MonoBehaviour {
	public float moveSpeed, maxSpeed, dragScale, initialDrag;
	public A_Logic_God logicGod;
	Vector3 moveDirection, mouseInput, mousePosition, lookDirection;

	// Use this for initialization
	void Start () {
		logicGod = GameObject.Find ("A_Cogoitator").GetComponent<A_Logic_God>();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
		rigidbody.AddForce(moveDirection * moveSpeed, ForceMode.Force);
		//rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

		rigidbody.drag = rigidbody.velocity.magnitude * dragScale + initialDrag;

		logicGod.playerPosition = transform.position;

		//For follow mouse
		mouseInput = Input.mousePosition;
		mouseInput.z = -Camera.main.transform.position.z;
		mousePosition = Camera.main.ScreenToWorldPoint (mouseInput);
		lookDirection = mousePosition - transform.position;
		transform.rotation = Quaternion.FromToRotation (Vector3.up, lookDirection);
	}
}
