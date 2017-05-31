using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldState;

public class Harvestable : Interactable {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}

	public override bool doAction () {
		Backpack bp = WorldState.Actors.player.GetComponent<Backpack> ();

		if (bp.add(parent.type, 1)) {
			WorldState.Actors.actionable.Remove (parent);
			Destroy (this.gameObject);
		}

		return true;
	}

	public override string getText () {
		return "Harvest";
	}
}
