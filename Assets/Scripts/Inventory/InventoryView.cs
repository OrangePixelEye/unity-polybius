using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private Image[] images = new Image[5];

    private int selected_item;

    public void updateInventory(int i, Item item)
    {
        if(item != null)
        {
            images[i].sprite = item.Sprite;
            images[i].gameObject.name = item.Name;
            return;
        }
        images[i].sprite = null;
        images[i].color = Color.white;
        images[i].gameObject.name = "None";
    }

    public void selectItem(int i)
    {
        Inventory.Instance.findItem(i);
        if(Inventory.Instance.Using_item != null)
        {
            images[i].color = Color.red;
            selected_item = i;
        }
    }

    public void itemViewClosed()
    {
        images[selected_item].color = Color.white;
        CameraController.Instance.MoveCamera = true;
    }
}