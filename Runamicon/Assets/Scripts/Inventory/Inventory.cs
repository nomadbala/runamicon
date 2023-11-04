using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	[SerializeField] private GameObject _player;
	private List<Item> _items;
	private Accessories _amulet;
	private List<Accessories> _rings;
	//private Health _health;
	//private Sword _sword;
	private void Awake() {
		_items = new List<Item>();
		//_health= _player.GetComponent<Health>();
		//_sword= _player.GetComponent<Sword>();
		_rings = new List<Accessories>();
		_amulet = null;
		TempFillInventory();
	}

	public void TempFillInventory() {
		_items.Add(new HealthPotion(3));
		_items.Add(new HealthAmulet(1));
		_items.Add(new HealthRing(1));

		_items.Add(new StrengthAmulet(1));
		_items.Add(new StrengthRing(1));

		_items.Add(new Food(1));
		_items.Add(new Drink(1));
	}
	private void Update() {
	
		if (Input.GetKeyDown(KeyCode.I)) { PrintInventory(); }
		if(Input.GetKeyDown(KeyCode.M)){
			Debug.Log("Amulet: "+_amulet?.GetItemType);
			Debug.Log("Rings: ");
			_rings.ForEach(r => { Debug.Log(r); });
		}
		if (Input.GetKeyDown(KeyCode.H)) { Debug.Log("HEAL"); RemoveItemAfterUse(Heal()); }
		if (Input.GetKeyDown(KeyCode.Alpha1)) { Debug.Log("Eat"); RemoveItemAfterUse(Eat()); }
		if (Input.GetKeyDown(KeyCode.Alpha2)) { Debug.Log("Drink"); RemoveItemAfterUse(Drink()); }
		if (Input.GetKeyDown(KeyCode.Alpha3)) { 
		  Debug.Log("HPAmulet");
		
			Accessories amulet =(Accessories) DressHealthAmulet();
			dressNewAmulet(amulet);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			Debug.Log("STRNGAmulet");

			Accessories amulet = (Accessories)DressStrengthAmulet();
			dressNewAmulet(amulet);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)){
			Debug.Log("HPRing");

			Accessories ring = (Accessories)DressHealthRing();
			dressNewRing(ring);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			Debug.Log("STRNGRing");

			Accessories ring = (Accessories)DressStrengthRing();
			dressNewRing(ring);
		}
	}
	private void dressNewAmulet(Accessories amulet) {
		if (amulet == null){ return; }
		RemoveItem(amulet);
		if (_amulet != null) {
			_amulet.CancelUse(_player);
			_items.Add(_amulet);
		}
		_amulet = amulet;
	}
	private void dressNewRing(Accessories ring) {
		if (ring == null) { return; }
		if (ring.Amount >= 0) {
	   	ring.Amount--;

		} else {
		  RemoveItem(ring);
		}
		
		if(_rings.Count>=6){
	    _rings.RemoveAt(0);
		}
		_rings.Add(ring);

	}
	private Item UseItem(ItemType type, string errMessage){
		foreach (Item item in _items) {
			if (item.GetItemType == type) {
				item.UseItem(_player);
				return item;
			}
		}
		Debug.Log(errMessage);
		return null;
	}
	private Item Heal() {
		return UseItem(ItemType.HealthPotion, "No healing potions");
	}
	private Item Eat() {
		return UseItem(ItemType.Food, "No foods");
	}
	private Item Drink() {
		return UseItem(ItemType.Drink, "No drinks");
	}
	private Item DressHealthAmulet() {
		return UseItem(ItemType.HealthAmulet, "No Health Amulets");
	}
	private Item DressStrengthAmulet() {
		return UseItem(ItemType.StrengthAmulet, "No Strength Amulet");
	}
	private Item DressHealthRing() {
		return UseItem(ItemType.HealthRing, "No Health Rings");
	}
	private Item DressStrengthRing() {
		return UseItem(ItemType.StrengthRing, "No Strength Rings");
	}

	private void PrintInventory() {
		foreach (Item item in _items) {
			Debug.Log(item.GetItemType + " "+ item.Amount);
		}
	}
	public void AddItem(Item item) {
	  foreach (Item _item in _items) {
			if (_item.GetItemType != item.GetItemType) {

				_items.Add(item);
			} else{
				_item.Amount++;
			}
		
		}
	  
	}


	public void RemoveItemAfterUse(Item item) {
		if (item !=null && item.IsNeedsRemove) {
			RemoveItem(item);
		}
	}
	public void RemoveItem(Item item) {
		_items.Remove(item);
	}

}
