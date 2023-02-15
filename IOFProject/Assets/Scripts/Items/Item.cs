using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
public string itemName;
public string itemDescription;

public Sprite itemSprite;

}