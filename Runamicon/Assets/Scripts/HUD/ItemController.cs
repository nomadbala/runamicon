using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
	public HudItem item;



	private InventoryController inventoryController;
	private void Awake() {
		inventoryController = GetComponentInParent<InventoryController>();
	}
	public void SelectItem() {
		inventoryController._description.SetActive(true);
		inventoryController._icon.sprite = item._icon;
		inventoryController._descrText.text = item._item.Description;
		inventoryController._itemInDescr = item;



	}

}
