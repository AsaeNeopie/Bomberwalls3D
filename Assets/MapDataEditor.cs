using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapData))]
public class MapDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Edit map"))
        {
            //LevelCustomisationWindow window = EditorWindow.GetWindow<LevelCustomisationWindow>();
           // window.LevelManager = Target;
            //window.Show();
        }
    }
}
