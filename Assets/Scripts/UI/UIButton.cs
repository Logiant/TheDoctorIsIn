using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {


	//two labels - button name and quantity
	//one image - the item icon

	public Button button;
	public Text nameLabel;
	public Text quantity;
	public Image iconImage;

	public void Setup(Item item) {
		nameLabel.text = item.itemName;
		quantity.text = "x" + item.stackSize;
		iconImage.GetComponentInChildren<Image>().sprite = item.iconImage;
	}

}
