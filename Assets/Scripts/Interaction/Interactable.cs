using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    public Texture2D cursorTextureNo;
    private BoxCollider2D my_collider;

    [SerializeField]
    private Item item;

    [SerializeField]
    private string item_name = "";

    // Start is called before the first frame update
    void Start() => my_collider = GetComponent<BoxCollider2D>();
    protected virtual void OnMouseUp() 
    {
        InteractionManager.Instance.showText(this.gameObject.name);
        if(item != null)
        {
            Inventory.Instance.addItem(item);
            doStuff();
        }
        if(item_name != "")
        {
            if(Inventory.Instance.verifyItem(item_name))
            {
                doStuff();return;
            }
        }
        //doStuff();        
    }
    
    void OnMouseEnter() => Cursor.SetCursor(cursorTextureNo, Vector2.zero, CursorMode.Auto);

    void OnMouseExit() => Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 

    protected virtual void doStuff(){}
    protected void inventoryClosed(object sender, EventArgs e)
	{

	}
    
}
