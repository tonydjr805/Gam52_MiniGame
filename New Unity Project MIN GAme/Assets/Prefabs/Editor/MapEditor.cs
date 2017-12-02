using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(MapGeneraotor))]
public class MapEditor : Editor {

    public override void OnInspectorGUI()
    {
        MapGeneraotor map = target as MapGeneraotor;
        if (DrawDefaultInspector()){
            map.GenerateMap();
        }
        if (GUILayout.Button("GenerateMap"))
        {
            map.GenerateMap();
        }

    }
}
