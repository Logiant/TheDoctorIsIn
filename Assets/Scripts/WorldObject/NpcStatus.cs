using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WorldState;

public class NpcStatus : Interactable {

//	static string water = "Water";
	//static string juice = "Juice";
	//static string nectar = "Nectar";

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}

/*	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("I'm so thirsty...");
			Backpack bp = other.GetComponent<Backpack> ();
			if (bp.take (water, 1)) {
				Debug.Log ("Thank you!");
				Destroy (this.gameObject);
			}

		}
	}
*/

	public override bool doAction () {
		bool cured = false;
	/*	//if the player has water, take one and disappear
		Backpack bp;
		if ((bp = Actors.player.GetComponent<Backpack> ()) != null) {

			if (bp.take (water, 1)) {
				cured = true;
				Debug.Log ("Thank you!");
				Actors.actionable.Remove (parent);
				Destroy (this.gameObject);
			}

		}

		//print a hint
		if (!cured) {
			Debug.Log ("I am so thirsty!");
		}
	*/	return cured;
	}

	public override string getText () {
		return "Cure";
	}

}
