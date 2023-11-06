using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryIcons : MonoBehaviour {
	public static InventoryIcons _Instance;

  [SerializeField] public Sprite _healthPotion;
  [SerializeField] public Sprite _food;
  [SerializeField] public Sprite _drink;
  [SerializeField] public Sprite _healthAmulet;
  [SerializeField] public Sprite _strengthAmulet;
  [SerializeField] public Sprite _strengthRing;
  [SerializeField] public Sprite _healthRing;

  public Sprite GetSprite(ItemType type) {
		switch (type) {
			case ItemType.HealthPotion:
			return _healthPotion;

			case ItemType.Food:
			return _food;

			case ItemType.Drink:
			return _drink;

			case ItemType.HealthAmulet:
			return _healthAmulet;

			case ItemType.StrengthAmulet:
			return _strengthAmulet;

			case ItemType.HealthRing:
			return _healthRing;

			case ItemType.StrengthRing:
			return _strengthRing;

		}
		return null;
	}
	private void Awake() {
		_Instance=this;
	}
}
