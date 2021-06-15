using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject map_base;

    [SerializeField]
    private GameObject btnPrefab;

    [SerializeField]
    private Transform map_position;

    [SerializeField]
    private GameObject map_panel;

    public event EventHandler OnMapOpen;

    private static MapController instance;
    public static MapController Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<MapController>();
            }
            return instance;
        }
    }

    public GameObject createRoom(MapBase map)
    {
        GameObject go = Instantiate(btnPrefab, map_position.position, Quaternion.identity,map.transform);
        return go;
    }

    private void Start()
    {
        CameraController.Instance.changeCameraLimits(map_base);
    }

    public void changeMap(GameObject new_map)
    {
        map_base.SetActive(false);
        new_map.SetActive(true);
        map_base = new_map;
        CameraController.Instance.changeCameraLimits(map_base);
    }

    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.M)) showMap();
    }

    private void showMap()
    {
        map_panel.SetActive(!map_panel.activeSelf);
        OnMapOpen?.Invoke(this, EventArgs.Empty);
    }
}
