using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InteractionManager : MonoBehaviour
{
    private static InteractionManager instance;
    public static InteractionManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<InteractionManager>();
            }
            return instance;
        }
    }

    public event EventHandler OnInteractionClosed;
    
    [SerializeField]
    private GameObject text_panel;
    private Text itens_text;

    [SerializeField]
    private GameObject image_panel;
    private Image itens_image;

    private void Start()
    {
        itens_text = text_panel.GetComponentInChildren(typeof(Text)) as Text;
        itens_image = image_panel.GetComponentInChildren(typeof(Image)) as Image;
    }

    public void showText(string name)
    {
        text_panel.SetActive(true);
        itens_text.text = GameManager.Instance.getText(name);
    }

    public void showImage(Sprite item)
    {
        image_panel.SetActive(true);
        itens_image.sprite = item;
    }

    public void textClosed()
    {
        OnInteractionClosed?.Invoke(this, EventArgs.Empty);
    }
}