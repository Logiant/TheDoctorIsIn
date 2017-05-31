using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoof : MonoBehaviour {

	public GameObject roof;

	// Use this for initialization
	void Start () {
		roof.SetActive (true);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			roof.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			roof.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
