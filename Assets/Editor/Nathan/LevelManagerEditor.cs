using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LevelManager))]
public class LevelManager_CustomInspector : Editor
{
    


    public override VisualElement CreateInspectorGUI()
    {
        return base.CreateInspectorGUI();
    }

    public override void OnInspectorGUI()
    {
        LevelManager Target = (LevelManager)target;

        base.OnInspectorGUI();

        GUILayout.Space(5);
        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
        GUILayout.Space(5);

        if (GUILayout.Button("Edit Scriptable Object"))
        {
            MapEditorWindow window = EditorWindow.GetWindow<MapEditorWindow>();
            window.Map = Target.MapData;
            window.Show();
        }
            

        if (GUILayout.Button("Rebuild Map"))
            Target.PopulateMap();
    }


}
