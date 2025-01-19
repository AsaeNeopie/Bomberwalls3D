using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


// Place the selected object randomly between the interval of the Min Max Slider
// in the X,Y,Z coords

class LevelCustomisationWindow : EditorWindow
{

    public LevelManager LevelManager;
    Rect r;

    

    void OnGUI()
    {

        //compute white rect
        float minSize;
        float TileSize;
        if (position.size.x < position.size.y) 
        {
            float ratio =  (float)LevelManager.Bounds.height / (float)LevelManager.Bounds.width;
            minSize = r.width = (float)position.size.x *.75f;
            r.height = r.width * ratio;

            TileSize = (float)minSize /(float)LevelManager.Bounds.width;
        }
        else
        {
            float ratio =  (float)LevelManager.Bounds.width / (float)LevelManager.Bounds.height;
            minSize = r.height = (float)position.size.y * .75f;
            r.width = r.height * ratio;

            TileSize = (float)minSize / (float)LevelManager.Bounds.height;

        }
        r.center = position.size/2f;
        Debug.Log(r);
        EditorGUI.DrawRect(r,Color.white);

        //draw Tiles
        for (int i = 0; i < LevelManager.Bounds.width; i++)
        {
            for (int j = 0; j < LevelManager.Bounds.height; j++)
            {
                
                Vector2Int key = new Vector2Int(i, j);
                if (LevelManager.Tiles.ContainsKey(key))
                {
                    Color c = Color.white;
                    switch (LevelManager.Tiles[new Vector2Int(i, j)])
                    {
                        case Tile.SolidBlock:
                            c = Color.black; break;
                        case Tile.BrickBlock:
                            c = Color.grey; break;
                        case Tile.PlayerSpawn:
                            c = Color.cyan; break;
                        case Tile.BombPickup:
                            c = Color.magenta; break;
                    }

                    EditorGUI.DrawRect(new Rect(r.position.x + i * TileSize + 1, r.position.y + j * TileSize + 1, TileSize - 2, TileSize - 2), c);
                }
                
                
                
            }
        }

        
    }


    private void OnEnable()
    {
        name = "Map Customization";
        titleContent = new( name);
        
    }


    private void OnDisable()
    {
        
    }



}

