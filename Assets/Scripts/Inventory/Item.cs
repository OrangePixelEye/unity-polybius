using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField]
    private string item_name = "default";

    public Sprite Sprite { get => sprite; }
    public string Name { get => item_name; }
}
