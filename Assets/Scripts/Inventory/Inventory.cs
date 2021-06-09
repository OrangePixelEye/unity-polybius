using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Item using_item;
    [SerializeField]
    private Item[] itens = new Item[5];
    private int using_slots = 0;

    private InventoryView view;

    private static Inventory instance;
    public static Inventory Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Inventory>();
            }
            return instance;
        }
    }

    void Awake()
    {
        view = GetComponent<InventoryView>();
    }

    public void addItem(Item item)
    {
        if(using_slots > itens.Length) return;
        for(int i = 0; i < itens.Length; i++)
        {
            if(itens[i] == null)
            {
                itens[i] = item;
                using_slots++;
                view.updateInventory(i, item);
                return;
            }
        }
    }

    public void findItem(int i)
    {
        using_item = itens[i];          
    }


    public bool verifyItem(string name_item)
    {
        if(using_item != null)
        {
            if(using_item.Name == name_item)
            {
                removeItem(using_item);
                return true;
            }
        }
        return false;
    }

    private void removeItem(Item item)
    {
        for(int i = 0; i < using_slots; i++)
        {
            if(itens[i] == item)
            {
                itens[i] = null;
                rearrangeInventory();
                return;
            }
        }
    }

    private void rearrangeInventory()
    {
        //rearrange in the inventory
        using_slots--;
        if(using_slots == 0) view.updateInventory(0, null);
        for(int i = 0 ; i < using_slots; i++)
        {
            if(itens[i] == null)
            {
                itens[i] = itens[i + 1];
                itens[i + 1] = null;
            }
            //update view
            view.updateInventory(i,itens[i]);
        }
    }
}