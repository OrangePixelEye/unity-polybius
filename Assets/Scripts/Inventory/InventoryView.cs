using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Image[] images = new Image[5];

    public void updateInventory(int i, Item item)
    {
        if(item != null)
        {
            //update sprite
            images[i].sprite = item.Sprite;
            //update go name
            images[i].gameObject.name = item.Name;
            return;
        }
        images[i].sprite = null;
        images[i].color = Color.white;
        images[i].gameObject.name = "None";
    }

    public void selectItem(int i)
    {
        images[i].color = Color.red;
        Inventory.Instance.findItem(i);
    }
}