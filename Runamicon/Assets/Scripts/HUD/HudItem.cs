using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu (fileName ="New Item", menuName ="Item/Create new Item")]
public class HudItem
{

  public int id;

  public Item _item;
  [SerializeField] public Sprite _icon;

  public HudItem(Item item, Sprite icon) {
    _icon=icon;
		_item = item;
  }
}
