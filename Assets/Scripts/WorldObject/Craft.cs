using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WorldState;

public class Craft : Interactable {

	List<Recipie> recipies;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		//generate recipies for the crafting station
		recipies = new List<Recipie> ();
		//TODO recipies should read from an XML or JSON file - allows easy modifications without rebuilding
		//and they don't have to be hardcoded either :-)
		string[] r = { "Grass" };
		string[] p = { "Water" };
		recipies.Add (new Recipie (r, p));

		string[] r2 = {"Red Flower"};
		string[] p2 = {"Juice"};
		recipies.Add (new Recipie (r2, p2));

		string[] r3 = {"Yellow Flower"};
		string[] p3 = {"Nectar"};
		recipies.Add (new Recipie (r3, p3));
	}

	public override string getText () {
		string str = "Craft: ";

		bool[] valid = validRecipies (Actors.player.GetComponent<Backpack> ());

		for (int i = 0; i < recipies.Count; i++) {
			if (valid [i]) {
				for (int j = 0; j < recipies[i].getProducts ().Length; j++) {
					str += recipies [i].getProducts () [j] + " ";
				}
			}

		}


		return str;
	}


	public override bool doAction () {
		/*
		Backpack bp = Actors.player.GetComponent<Backpack> ();
		bool[] valid = validRecipies (bp);
		bool[] completed = new bool[recipies.Count];


		for (int i = 0; i < recipies.Count; i++) {
			completed [i] = false;
			if (valid [i]) {
				completed [i] = true;
				for (int j = 0; j < recipies[i].getReagents ().Length; j++) {
					bp.take (recipies [i].getReagents () [j], 1);
				}
				valid = validRecipies (bp);
			}
		}
		for (int i = 0; i < recipies.Count; i++) {
			if (completed [i]) {
				string[] prod = recipies [i].getProducts ();

				for (int j = 0; j < prod.Length; j++) {
					bp.add (prod [j], 1);
				}

			}
		}*/
		return true;
	}


	private bool[] validRecipies(Backpack bp) {
		bool[] valid = new bool[recipies.Count];
		/*
		for (int i = 0; i < recipies.Count; i++) {
			valid [i] = true;
			Recipie res = recipies [i];
			string[] reagents = res.getReagents ();

			for (int j = 0; j < reagents.Length; j++) {
				valid [i] = valid [i] & (bp.peek (reagents [j]) > 0) ;
			}
		}*/
		return valid;
	}

}
