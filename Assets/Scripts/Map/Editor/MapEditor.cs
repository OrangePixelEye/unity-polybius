using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MapBase))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapBase mapBase = (MapBase)target;

         //return true if button is pressed
        if(GUILayout.Button("Create Room"))
        {
            GameObject room = MapController.Instance.createRoom(mapBase);
            if(!mapBase.Is_full)
                mapBase.addRoom(room);
            else
                DestroyImmediate(room);
        }
    }
}
