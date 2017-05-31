using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WorldState;

public class WorldObject : MonoBehaviour {

	new public string name;

	public uint type; //item type!! 

	bool inRange = false;

	Interactable[] components;

	// Use this for initialization
	protected virtual void Start () {
		components = GetComponentsInChildren<Interactable> ();
	}

	void Update () {
		if (inRange && Input.GetButtonUp ("Jump")) {
			for (int i = 0; i < components.Length; i++) {
				if (components [i].doAction ()) {
					return;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			inRange = true;
			Actors.actionable.Add (this);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			inRange = false;
			Actors.actionable.Remove (this);
		}
	}

	new public string ToString () {
		string descr = name + ": ";
		for (int i = 0; i < components.Length; i++) {
			descr += components [i].getText () + " ";
		}
		return descr;
	}

}
