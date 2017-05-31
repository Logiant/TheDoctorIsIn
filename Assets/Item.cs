using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item {
	//item's "database index"
	public uint type;
	//item's value in gold
	public int value;
	//item's icon
	public Sprite iconImage;
	//item's name
	public string itemName;
	//stacking properties
	public bool stack;
	public uint stackSize;

	public Item(uint type, int goldValue, Sprite icon, string name, bool stackable) {
		value = goldValue;
		iconImage = icon;
		itemName = name;
		this.type = type;
		stack = stackable;
		this.stackSize = 0;
	}

	public Item(Item toCopy) {
		type = toCopy.type;
		value = toCopy.value;
		iconImage = toCopy.iconImage;
		itemName = toCopy.itemName;
		stack = toCopy.stack;
		stackSize = toCopy.stackSize;
	}
}

public static class ItemFactory {
	//item types
	public static uint RED_FLOWER = 0;
	public static uint YELLOW_FLOWER = 1;
	public static uint GRASS = 2;
	public static uint JUICE = 3;
	public static uint NECTAR = 4;
	public static uint WATER = 5;

	static Dictionary<uint, Item> prefabs;

	//TODO add an int param to load dynamically?
	//TODO this can be replaced with a text file to parse through...
	static void LoadPrefabs() {
		Item prefab = new Item (RED_FLOWER, 2, ResourceHandler.LoadIcon("RedFlower"),
																	   "Red Flower", true);
		prefabs.Add (RED_FLOWER, prefab);

		prefab = new Item (YELLOW_FLOWER, 2, ResourceHandler.LoadIcon("YellowFlower"),
																	 "Yellow Flower", true);
		prefabs.Add (YELLOW_FLOWER, prefab);

		prefab = new Item (GRASS, 2, ResourceHandler.LoadIcon("Grass"),
			                                                 "Grass", true);
		prefabs.Add (GRASS, prefab);

		prefab = new Item (JUICE, 4, ResourceHandler.LoadIcon("Juice"),
															 "Juice", true);
		prefabs.Add (JUICE, prefab);

		prefab = new Item (NECTAR, 4, ResourceHandler.LoadIcon("Nectar"),
															  "Nectar", true);
		prefabs.Add (NECTAR, prefab);

		prefab = new Item (WATER, 4, ResourceHandler.LoadIcon("Water"),
															 "Water", true);
		prefabs.Add (WATER, prefab);
	}

	public static Item BuildGeneric(uint type) {
		if (prefabs == null) {
			prefabs = new Dictionary<uint, Item> ();
			ItemFactory.LoadPrefabs ();
		}
		//return a copy of the preset
		return new Item(prefabs[type]);
	}

}