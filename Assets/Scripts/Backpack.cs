using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {
	//toggles on when the Backpack has been updated
	//lets the UI know to update
	public bool updated = true;
	//stored items
	Dictionary<uint, List<Item>> items; //item ID, list of items
	//amount of gold in the bag
	private uint gold = 0;

	public uint currentGold() {
		return gold;
	}

	public bool giveGold(uint amt) {
		gold += amt;
		return true;
	}

	public bool takeGold(uint amt) {
		bool valid = false;
		if (amt <= gold) {
			gold -= amt;
			valid = true;
		}
		return valid;
	}

	// Use this for initialization
	void Start () {
		//start with an empty bag. So sad! :-(
		items = new Dictionary<uint, List<Item>> ();
	}

	public Dictionary<uint, List<Item>> getItems() {
		return items;
	}
	//functions for stackable items
	public bool add(uint type, uint qty) {
		bool success = addStackable (type, qty);
		updated = updated | success;
		return success;
	}
	public bool take(uint type, uint qty) {
		bool success = takeStackable (type, qty);
		updated = updated | success;
		return success;
	}
	//functions for unique items
	public bool add(Item item) {
		Debug.Log ("Not Implemented");
		return false;
	}
	public bool take(uint type, Item item) {
		Debug.Log ("Not Implemented");
		return false;
	}



	//Add stackable items to this inventory
	private bool addStackable(uint type, uint qty) {
		Item prototype = ItemFactory.BuildGeneric (type);
		if (!prototype.stack) { //catch a stacking error
			Debug.LogError ("ERROR! Tried to stack " + prototype.itemName + " with " + gameObject.name + ". Not Stackable!!!");
			return false;
		}
		if (!items.ContainsKey (type)) {
			items.Add (type, new List<Item>());
			items [type].Add (prototype);
		}
		items [type] [0].stackSize += qty;
		return true;
	}

	private bool takeStackable(uint type, uint qty) {
		//make sure the item exists
		if (!items.ContainsKey (type) || items[type].Count == 0) {
			Debug.LogError("ERROR! Tried to take stackable ID# " + type + " from "+gameObject.name+". Item not in inventory!!!");
			return false;
		}
		if (!items[type][0].stack) { //catch a stacking error
			Debug.LogError ("ERROR! Tried to de-stack " + items[type][0].itemName + " from " + gameObject.name + ". Not Stackable!!!");
			return false;
		}

		bool success = false;
		if (items[type][0].stackSize >= qty) {
			items [type][0].stackSize -= qty;
			success = true;
		}
		return success;
	}

	public uint peek(uint type) {
		if (!items.ContainsKey (type) || items[type].Count == 0) {
			return 0;
		}
		uint qty = 0;
		if (items [type] [0].stack) {
			qty = items [type] [0].stackSize;
		} else {
			qty = (uint)items [0].Count;
		}
		return qty;

	}

	// Update is called once per frame
	void Update () {
		
	}
}
