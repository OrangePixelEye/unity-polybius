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

    private void Start()
    {
        itens_text = text_panel.GetComponentInChildren(typeof(Text)) as Text;
    }

    public void showText(string name)
    {
        text_panel.SetActive(true);
        itens_text.text = GameManager.Instance.getText(name);
    }

    public void textClosed()
    {
        OnInteractionClosed?.Invoke(this, EventArgs.Empty);
    }
}