using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

	protected WorldObject parent;
	new public string name;

	protected virtual void Start () {
		parent = GetComponentInParent<WorldObject> ();
		name = parent.name;
	}



	public abstract bool doAction ();

	public abstract string getText();
}
