using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

//HealthPotion
//Food
//Drink
//HealthAmulet
//StrengthAmulet
//HealthRing
//StrengthRing



public class HealthPotion : Item {
	private float _healingPower;
	public float HealingPower => _healingPower;

	public HealthPotion(int amount) : base(amount, ItemType.HealthPotion) {
		_healingPower =  40f;
		//IsNeedsRemove = true;
		_description = $"Heals your health by {_healingPower} HP";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		_amount--;
		if(_amount==0){ IsNeedsRemove = true; }
		Health health = component.GetComponent<Health>();
		if (health) {
			health.Heal(_healingPower);
		}
	}

}
public class Food : Item {
	private float _healingPower;
	public float HealingPower => _healingPower;

	public Food(int amount) : base(amount, ItemType.Food) {
		_healingPower = 10f;
		//IsNeedsRemove = true;
		_description = $"A little heals your health by {_healingPower} HP";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		_amount--;
		if (_amount == 0) { IsNeedsRemove = true; }
		Health health = component.GetComponent<Health>();
		if (health) {
			health.Heal(_healingPower);
		}
	}

}
public class Drink : Item {
	private float _healingPower;
	public float HealingPower => _healingPower;

	public Drink(int amount) : base(amount, ItemType.Drink) {
		_healingPower = 10f;
		//IsNeedsRemove = true;
		_description = $"A little heals your health by {_healingPower} HP";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		_amount--;
		if (_amount == 0) { IsNeedsRemove = true; }
		Health health = component.GetComponent<Health>();
		if (health) {
			health.Heal(_healingPower);
		}
	}


}

public class HealthAmulet : Accessories {
	private float _healthIncrease;
	public float HealthIncrease => _healthIncrease;

	public HealthAmulet(int amount) : base(amount, ItemType.HealthAmulet) {
		_healthIncrease = 30f;
		IsNeedsRemove = false;
		_description = $"Increases character's maximum health by {_healthIncrease} HP";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		Health health = component.GetComponent<Health>();
		if (health) {
			health.SetMaxHealth(health._maxHealth + _healthIncrease);
		}
	}

	public override void CancelUse(GameObject component) {
		Health health = component.GetComponent<Health>();
		if (health) {
			_isUsed = false;
			health.SetMaxHealth(health._maxHealth - _healthIncrease);
		}
	}
}
public class StrengthAmulet : Accessories {
	private float _strengthIncrease;
	public float StrengthIncrease => _strengthIncrease;

	public StrengthAmulet(int amount) : base(amount, ItemType.StrengthAmulet) {
		_strengthIncrease = 15f;
		IsNeedsRemove = false;
		_description = $"Increases character's maximum damage by {_strengthIncrease} dmg";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		Sword sword = component.GetComponent<Sword>();
		if (sword) {
			sword.SetDamage(sword.Damage + _strengthIncrease);
		}
	}

	public override void CancelUse(GameObject component) {
		Sword sword = component.GetComponent<Sword>();
		if (sword) {
			_isUsed = false;
			sword.SetDamage(sword.Damage - _strengthIncrease);
		}
	}
}

public class HealthRing : Accessories {
	private float _healthIncrease;
	public float HealthIncrease => _healthIncrease;

	public HealthRing(int amount) : base(amount, ItemType.HealthRing) {
		_healthIncrease = 10f;
		IsNeedsRemove = false;
		_description = $"A little increases character's maximum health by {_healthIncrease} HP";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		Health health = component.GetComponent<Health>();
		if (health) {
			health.SetMaxHealth(health._maxHealth + _healthIncrease);
		}
	}

	public override void CancelUse(GameObject component) {
		Health health = component.GetComponent<Health>();
		if (health) {
			_isUsed = false;
			health.SetMaxHealth(health._maxHealth - _healthIncrease);
		}
	}
}
public class StrengthRing : Accessories {
	private float _strengthIncrease;
	public float StrengthIncrease => _strengthIncrease;

	public StrengthRing(int amount) : base(amount, ItemType.StrengthRing) {
		_strengthIncrease = 5f;
		IsNeedsRemove = false;
		_description = $"A little increases character's maximum damage by {_strengthIncrease} dmg";
	}

	public override void UseItem(GameObject component) {
		_isUsed = true;
		Sword sword = component.GetComponent<Sword>();
		if (sword) {
			sword.SetDamage(sword.Damage + _strengthIncrease);
		}
	}

	public override void CancelUse(GameObject component) {
		Sword sword = component.GetComponent<Sword>();
		if (sword) {
			_isUsed = false;
			sword.SetDamage(sword.Damage - _strengthIncrease);
		}
	}
}
