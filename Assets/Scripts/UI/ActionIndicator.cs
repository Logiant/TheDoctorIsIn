using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using WorldState;

public class ActionIndicator : MonoBehaviour {

	Text actionText;

	// Use this for initialization
	void Start () {
		actionText = GetComponentInChildren<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (WorldState.Actors.actionable.Count > 0) {
			actionText.text = "";
			for (int i = 0; i < Actors.actionable.Count; i++) {
				actionText.text += Actors.actionable [i].ToString() + "\n";
			}


		} else {
			actionText.text = "";
		}
	}
}
