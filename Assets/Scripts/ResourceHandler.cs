using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public static class ResourceHandler {

	static Dictionary<string, Sprite> icons;

	public static Sprite LoadIcon(string name) {
		if (icons == null) {
			Initialize ();
		}

		Sprite imageIcon = null;
		//only load each image once
		if (icons.ContainsKey (name)) {
			imageIcon = icons [name];
		} else {
			//load the icon
			imageIcon = Resources.Load<Sprite>("Icons/" + name);
			icons.Add(name, imageIcon);
			Debug.Log (imageIcon.name);
		}

		return imageIcon;
	}

	static void Initialize () {
		icons = new Dictionary<string, Sprite> ();
	}


}
