using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : Interactable
{
    [SerializeField]
    private GameObject inventory;
    private bool clicked = false;

    void Start()
    {
        InteractionManager.Instance.OnInteractionClosed += inventoryClosed;
    }

    new void inventoryClosed(object sender, EventArgs e)
	{
        StartCoroutine(up());
	}

    private IEnumerator up()
    {
        bool up = true;
        RectTransform rect = inventory.GetComponent<RectTransform>();
        float x = rect.anchoredPosition.x;
        float y = rect.anchoredPosition.y;
        float z = 0;

        while(up && clicked)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            y += 0.2f;
            rect.anchoredPosition = new Vector3(x, y, z);
            if(y >= 40f)
            {
                Destroy(gameObject);
                InteractionManager.Instance.OnInteractionClosed -= inventoryClosed;
            } 
        } 
    }

    protected override void doStuff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        clicked = true;
    }
}
