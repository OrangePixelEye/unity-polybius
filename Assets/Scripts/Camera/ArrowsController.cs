using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class ArrowsController : MonoBehaviour
{
    private static ArrowsController instance;
    public static ArrowsController Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ArrowsController>();
            }
            return instance;
        }
    }

    public enum arrows
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }

    [System.Serializable]
    struct Ui_Arrows
    {
        public GameObject top;
        public GameObject left;
        public GameObject right;
        public GameObject bottom;
    }

    [SerializeField]
    private Ui_Arrows ui_arrows;

    public void hideArrow(arrows arrow)
    { 
        switch(arrow)
        {
            case arrows.TOP:
                ui_arrows.top.SetActive(false);
                break;
            case arrows.BOTTOM:
                ui_arrows.bottom.SetActive(false);
                break;
            case arrows.LEFT:
                ui_arrows.left.SetActive(false);
                break;
            case arrows.RIGHT:
                ui_arrows.right.SetActive(false);
                break;
            default:
                print("arrow not found");
                break;
        }
    }
    public void hideArrow()
    {
        ui_arrows.top.SetActive(true);
        ui_arrows.bottom.SetActive(true);
        ui_arrows.right.SetActive(true);
        ui_arrows.left.SetActive(true);
    }
}
