using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
	public static InventoryController _Instance;
	public List<HudItem> _hudItems;

	[SerializeField] public Transform _itemContent;
	[SerializeField] public GameObject _inventoryItem;
	private void Awake() {
		_Instance = this;
		_hudItems = new List<HudItem>();
	}

	public void Add(HudItem item) {
		if (_hudItems.Count == 0) {
			item.id = 0;
		} else {
			item.id = _hudItems[_hudItems.Count - 1].id + 1;
		}
		_hudItems.Add(item);
		
	}
	public void Remove(Item removedItem) {
		foreach (HudItem item in _hudItems) {
			if (item._item == removedItem) {
				_hudItems.Remove(item);
				return;
			}
		}

	}
	public void ChangeItemInUI(bool isRemoved = false) {
		if (isRemoved) {
			foreach (Transform i in _itemContent) {
				Destroy(i.gameObject);
			}
			foreach (HudItem i in _hudItems) {
				SetItem(i);
			}
		} else {

			SetItem(_hudItems[_hudItems.Count - 1]);
		}
	}
	private void SetItem(HudItem itemHud) {
		var item = itemHud;
		GameObject _object = Instantiate(_inventoryItem, _itemContent);
		var _itemAmount = _object.transform.Find("ItemAmount").GetComponent<Text>();
		var _itemIcon = _object.transform.Find("ItemIcon").GetComponent<Image>();

		_itemAmount.text = item._item.Amount.ToString();
		_itemIcon.sprite = item._icon;
	}


}
