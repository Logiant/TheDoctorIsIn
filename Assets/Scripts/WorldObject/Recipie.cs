using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipie {

	//TODO handling multiple of each type (eg 3 blue flowers for 1 clarity)
	string[] reagents, products;

	public Recipie(string[] reagents, string[] products) {
		this.reagents = reagents;
		this.products = products;
	}

	public string[] getReagents() {
		return reagents;
	}


	public string[] getProducts() {
		return products;
	}
}
