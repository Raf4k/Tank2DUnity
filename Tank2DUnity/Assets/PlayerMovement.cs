using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private float turnSpeed = 5f;
	private Vector2 movement;

	public float moveSpeed = 10f;
	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = transform.position;

		if (Input.touchCount > 0) {
			Debug.Log("sdsa");
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				Vector2 moveTowards = Camera.main.ScreenToWorldPoint(touch.position);
				movement = moveTowards - currentPosition;
				movement.Normalize();
			}
		}
		float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -targetAngle), turnSpeed * Time.deltaTime);
	}

	void touch () {
		
	}
}

