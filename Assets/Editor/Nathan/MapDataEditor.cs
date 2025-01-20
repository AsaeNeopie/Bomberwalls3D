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

            MapEditorWindow window = EditorWindow.GetWindow<MapEditorWindow>();
            window.Map = (MapData)target;
            window.Show();
        }

        if (GUILayout.Button("Clear map"))
        {
            ((MapData)target).Tiles.Clear();
        }
    }
}
