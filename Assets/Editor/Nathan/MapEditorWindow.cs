using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class MapEditorWindow : EditorWindow
{

    public MapData Map;

    Rect _canvas;
    float _tileSize;

    int _selectedTile;
    readonly Tile[] _tileTypes = new Tile[5] {Tile.SolidBlock,Tile.BrickBlock,Tile.BombPickup,Tile.PlayerSpawn,Tile.Air };
    void OnGUI()
    {

        //Draw(20, () => EditorGUI.LabelField(r, "Label2"));
        EditorGUILayout.LabelField("Canvas");

        UpdateCanvas();
        HandleInputs();
        DrawCanvas();

        EditorGUILayout.LabelField("Palette");
        _selectedTile = GUILayout.SelectionGrid(_selectedTile, new GUIContent[4]
        {
            new GUIContent("SolidBlock"),
            new GUIContent("BrickBlock"),
            new GUIContent("BombPickup"),
            new GUIContent("PlayerSpawn")
        }, 4);

        EditorGUILayout.Separator();
        if (GUILayout.Button("generate solid tiles")) Map.GenerateTilingWalls();
        if(GUILayout.Button("Clear"))Map.Tiles.Clear();
    }



    void HandleInputs()
    {
        
        if (Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag)
        {
            if (_canvas.Contains(Event.current.mousePosition))
            {
                // Debug.Log(canvas.min);
                Vector2Int c = ((Vector2)math.remap(_canvas.min, _canvas.max, (Vector2)Map.Bounds.min, (Vector2)Map.Bounds.max, Event.current.mousePosition)).floor();
                Map.Tiles[new Vector2Int(c.x, c.y)] = _tileTypes[_selectedTile];
                EditorUtility.SetDirty(Map);
                Event.current.Use();
            }
        }
    }

    void UpdateCanvas()
    {

        //compute white rect
        float minSize;
        float ratio = (float)Map.Bounds.height / (float)Map.Bounds.width;
        if (position.size.x * ratio < position.size.y)
        {

            minSize = _canvas.width = (float)position.size.x * .75f;
            _canvas.height = _canvas.width * ratio;

            _tileSize = (float)minSize / (float)Map.Bounds.width;
        }
        else
        {

            minSize = _canvas.height = (float)position.size.y * .75f;
            _canvas.width = _canvas.height / ratio;

            _tileSize = (float)minSize / (float)Map.Bounds.height;

        }


        _canvas.center = new Vector2(position.size.x * 0.5f, _canvas.height * 0.5f + EditorGUILayout.GetControlRect().y);
        GUILayout.Space(_canvas.height);
    }

    void DrawCanvas()
    {
        
        if (Event.current.type == EventType.Repaint)
        {
            EditorGUI.DrawRect(_canvas, Color.white);

            //draw all tiles inside white area
            for (int i = 0; i < Map.Bounds.width; i++)
            {
                for (int j = 0; j < Map.Bounds.height; j++)
                {

                    Vector2Int key = new Vector2Int(i+Mathf.FloorToInt(Map.Bounds.xMin), j+ Mathf.FloorToInt(Map.Bounds.yMin));
                    if (Map.Tiles.ContainsKey(key))
                    {
                        Color c = Color.white;
                        switch (Map.Tiles[key])
                        {
                            case Tile.SolidBlock:
                                Debug.Log(_selectedTile);
                                c = Color.black; break;
                            case Tile.BrickBlock:
                                c = Color.grey; break;
                            case Tile.PlayerSpawn:
                                c = Color.cyan; break;
                            case Tile.BombPickup:
                                c = Color.magenta; break;
                        }

                        EditorGUI.DrawRect(new Rect(_canvas.position.x + i * _tileSize + 1, _canvas.position.y + j * _tileSize + 1, _tileSize - 2, _tileSize - 2), c);
                    }

                }
            }
        }
        
    }

    private void OnEnable()
    {
        name = "Map Customization";
        titleContent = new(name);

    }


    private void OnDisable()
    {
        AssetDatabase.SaveAssetIfDirty(Map);
    }



}
