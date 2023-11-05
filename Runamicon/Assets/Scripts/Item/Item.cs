using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
	protected int _amount;

	static private int _minAmount = 1;
	static private int _maxAmount = 3;
	public int Amount { get => _amount; set => _amount = value; }

	protected ItemType _itemType = ItemType.HealthPotion;
	public ItemType GetItemType => _itemType;

	protected string _description;
	public string Description { get => _description; set => _description = value; }

	protected bool _isNeedsRemove;
	public bool IsNeedsRemove { get => _isNeedsRemove; set => _isNeedsRemove = value; }

	protected bool _isUsed;
	public bool IsUsed { get; set; }
	protected Item(int amount, ItemType type) {
		_amount = amount;
		_itemType = type;
	}


	public abstract void UseItem(GameObject component);

	static protected void GetRandomItem() {
		Array vals = Enum.GetValues(typeof(ItemType));
		int amount = UnityEngine.Random.Range(_minAmount, _maxAmount);
		ItemType type = (ItemType)vals.GetValue(UnityEngine.Random.Range(0, vals.Length - 1));

		switch (type) {
			case ItemType.HealthPotion:

			break;
			case ItemType.Food:

			break;
			case ItemType.Drink:

			break;
			case ItemType.HealthAmulet:

			break;
			case ItemType.StrengthAmulet:

			break;
			case ItemType.HealthRing:

			break;
			case ItemType.StrengthRing:

			break;
		}

	}

	static public Item GetItem(int amount, ItemType type) {
		switch (type) {
			case ItemType.HealthPotion:
			return new HealthPotion(amount);

			case ItemType.Food:
			return new Food(amount);

			case ItemType.Drink:
			return new Drink(amount);

			case ItemType.HealthAmulet:
			return new HealthAmulet(amount);

			case ItemType.StrengthAmulet:
			return new StrengthAmulet(amount);

			case ItemType.HealthRing:
			return new HealthRing(amount);

			case ItemType.StrengthRing:
			return new StrengthRing(amount);

		}
		return null;
	}
}

public abstract class Accessories : Item {
	protected Accessories(int amount, ItemType type) : base(amount, type) { }
	public abstract void CancelUse(GameObject component);
}

public enum ItemType {
	HealthPotion,
	Food,
	Drink,
	HealthAmulet,
	StrengthAmulet,
	HealthRing,
	StrengthRing,
}