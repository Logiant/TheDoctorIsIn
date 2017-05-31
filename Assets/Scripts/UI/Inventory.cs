using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//object we're displaying the inventory for
	public Backpack player;
	//button prefab
	public GameObject button;
	//scroll container for holding object buttons
	public GameObject scrollContainer;
	public Text goldIndicator;

	Dictionary<uint, List<Item>> items;
	// Use this for initialization
	void Start () {

		items = player.getItems ();

	//	Instantiate(button

	}
	
	// Update is called once per frame
	void Update () {

		goldIndicator.text = "Gold: " + player.GetComponent<Backpack> ().currentGold ();


		if (player.updated) {
			Debug.Log ("BP Updated!");
			Button[] bOld = scrollContainer.GetComponentsInChildren<Button> ();
			for (int i = 0; i < bOld.Length; i++) {
				Destroy (bOld[i].gameObject);
			}
			foreach (KeyValuePair<uint, List<Item>> itemList in items) {
				if (itemList.Value.Count > 0) {
					//TODO don't assume stackable
					UIButton ub = (Instantiate(button, scrollContainer.transform) as GameObject).GetComponent<UIButton>();;
					ub.Setup (itemList.Value [0]);
				}
			}
			player.updated = false;
		}

	}
}
