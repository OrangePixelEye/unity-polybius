using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBase : MonoBehaviour
{
    [SerializeField]
    private MapBase firstRoom = null;
    [SerializeField]
    private MapBase secondRoom = null;
    [SerializeField]
    private MapBase thirdRoom = null;

    [SerializeField]
    public bool isLocked = true;

    private bool is_full = false;

    [SerializeField]
    private GameObject scene = null;

    public bool Is_full
    {
        get 
        {
            if(!thirdRoom)
                is_full = false;
            return is_full;
        } 
    }

    public void changeScene()
    {
        if(!isLocked)
        {
            if(scene)
            {
                MapController.Instance.changeMap(scene);
            }
        }
    }

    public void addRoom(GameObject new_room)
    {
        if(!firstRoom || (secondRoom && thirdRoom))
        {
            firstRoom = new_room.GetComponent<MapBase>();
        }
        else if(!secondRoom || (firstRoom && thirdRoom))
        {
            secondRoom = new_room.GetComponent<MapBase>();
        }
        else if(!thirdRoom)
        {
            thirdRoom = new_room.GetComponent<MapBase>();
            is_full = true;
        }
        else
        {
            Debug.Log("The three rooms are being used!");
        }
    }
}
