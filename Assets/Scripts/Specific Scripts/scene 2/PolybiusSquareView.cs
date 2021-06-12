using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolybiusSquareView : Interactable
{
    [SerializeField]
    private GameObject polybius;
    protected override void doStuff()
    {
        polybius.SetActive(true);
        Destroy(gameObject);
    }
}
