using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Interactable
{
    [SerializeField]
    private GameObject new_room;

    protected override void doStuff()
    {
        MapController.Instance.changeMap(new_room);
    }
}
