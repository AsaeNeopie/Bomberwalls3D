using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/*
[CustomPropertyDrawer(typeof(MapInfo))]
public class MapInfoDrawer : PropertyDrawer
{
    SerializedProperty EditedProperty;

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        // Create property container element.
        var container = new VisualElement();

        // Create property fields.
        var f1 = new PropertyField(property.FindPropertyRelative("Start_Inclusive"));
        var f2 = new PropertyField(property.FindPropertyRelative("End_Exclusive"));
        var f3 = new PropertyField(property.FindPropertyRelative("BombCount"));
        var f4 = new PropertyField(property.FindPropertyRelative("BricksCount"));
        var f5 = new PropertyField(property.FindPropertyRelative("SolidWallsPercentage"));

        // Add fields to the container.
        container.Add(f1);
        container.Add(f2);
        container.Add(f3);
        container.Add(f4);
        container.Add(f5);

        return container;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //EditorGUILayout.PropertyField(property);
       
        
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        if (property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, "Map info :"))
        {
            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;



            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Start_Inclusive"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("End_Exclusive"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("BombCount"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("BricksCount"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("SolidWallsPercentage"));
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            if (GUILayout.Button("Edit"))
            {
                LevelCustomisationWindow window = EditorWindow.GetWindow<LevelCustomisationWindow>();
                window.property = property;
                window.Init();
            }
            
           
        }
        EditorGUI.EndProperty();
    }

}
*/