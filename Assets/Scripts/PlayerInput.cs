using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldState;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour {

	CharacterController cc;

	Vector3 movement;

	public float speed = 5.5f;

	// Use this for initialization
	void Start () {
		WorldState.Actors.player = this.gameObject;
		cc = GetComponent<CharacterController> ();	

		movement = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

	}

	void FixedUpdate() {
		cc.SimpleMove (movement.normalized * speed);
	}
}
