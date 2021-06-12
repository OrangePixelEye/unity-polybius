using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolybiusFound : Interactable
{
    [SerializeField]
    private GameObject new_room;
    protected override void OnMouseUp()
    {
        MapController.Instance.changeMap(new_room);
    }
}
