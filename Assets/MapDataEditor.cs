using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MapData))]
public class MapDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Edit map"))
        {

            MapEditorWindow window = EditorWindow.GetWindow<MapEditorWindow>();
            window.Map = (MapData)target;
            window.Show();
        }
    }
}
