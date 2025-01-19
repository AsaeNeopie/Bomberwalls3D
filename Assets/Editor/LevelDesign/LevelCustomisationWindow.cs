using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static PlasticGui.WorkspaceWindow.Merge.MergeInProgress;


// Place the selected object randomly between the interval of the Min Max Slider
// in the X,Y,Z coords

class LevelCustomisationWindow : EditorWindow
{
    MapInfo Info = new();
    public SerializedProperty property;

    //inputs
    Vector2 _lastMousePosition;
    bool _mouseButtonDown;

    Rect r = new();

    void HandleEvents()
    {
        switch (Event.current.type)
        {
            case EventType.MouseDrag:
                _lastMousePosition = Event.current.mousePosition;
                Event.current.Use();
                break;

            case EventType.MouseDown:
                _lastMousePosition = Event.current.mousePosition;
                _mouseButtonDown = true;
                Event.current.Use();
                break;

            case EventType.MouseUp:
                _lastMousePosition = Event.current.mousePosition;
                _mouseButtonDown = false;
                Event.current.Use();
                break;
            case EventType.Repaint:
                r = EditorGUILayout.GetControlRect();
                Event.current.Use();
                break;
        }
    }

    void OnGUI()
    {
        HandleEvents();

        //background
        EditorGUI.DrawRect(r, new Color(.8f, 1, 1, .5f));
        //handle
        if (_mouseButtonDown)
        {
            Info.BombCount = PixelLengthToBlockCount((int)(_lastMousePosition.x - r.position.x), r);
        }
        Debug.Log("-");
        Debug.Log(r);
        Debug.Log(Event.current);
        Rect Handle = new Rect(new Vector2(BlockCountToPixelLength(Info.BombCount, r), r.position.y), new Vector2(5, r.height));
        EditorGUI.DrawRect(Handle, Color.white);
        
    }

    int PixelLengthToBlockCount(int p,Rect r)
    {
        return (int)((float)p/ (float)r.width * Info.freeSpaces);
    }

    int BlockCountToPixelLength(int b, Rect r)
    {
        return (int)((float)b/ Info.freeSpaces * (float)r.width);
    }

    public void Init()
    {
        Info = new();
        Info.Start_Inclusive = property.FindPropertyRelative("Start_Inclusive").vector2IntValue;
        Info.End_Exclusive = property.FindPropertyRelative("End_Exclusive").vector2IntValue;
        Info.BombCount = property.FindPropertyRelative("BombCount").intValue;
        Info.BricksCount = property.FindPropertyRelative("BricksCount").intValue;
        Info.SolidWallsPercentage = property.FindPropertyRelative("SolidWallsPercentage").floatValue;
        Debug.Log(Info.BombCount);

    }

    private void OnDisable()
    {
        property.FindPropertyRelative("Start_Inclusive").vector2IntValue = Info.Start_Inclusive;
        property.FindPropertyRelative("End_Exclusive").vector2IntValue = Info.End_Exclusive;
        property.FindPropertyRelative("BombCount").intValue = Info.BombCount;
        property.FindPropertyRelative("BricksCount").intValue = Info.BricksCount;
        property.FindPropertyRelative("SolidWallsPercentage").floatValue = Info.SolidWallsPercentage;
        property.serializedObject.ApplyModifiedProperties();
    }



}

