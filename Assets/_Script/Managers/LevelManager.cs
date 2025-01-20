using System;
using System.Collections.Generic;
using UnityEngine;

public enum Tile {SolidBlock,BrickBlock,BombPickup,PlayerSpawn,Air};
public class LevelManager : MonoBehaviour
{

    public List<Vector2Int> FreeSpaces { get; private set; } = new();
    public Dictionary<Vector2Int,Tile?> Tiles = new();

    
    public RectInt Bounds;//custom inspector avec bouton "edit" qui ouvre une window comme pour les couleurs

    //notifier
    public event Action OnMapUpdated;

    [Header("Prefab references")]
    [SerializeField] GameObject _bombPickupPrefab;
    [SerializeField] GameObject _brickBlockPrefab;
    [SerializeField] GameObject _solidBlockPrefab;


    [HideInInspector] public List<Transform> SpawnSockets;

    public MapData MapData;

    //bouton open map edition window

    private void Start()
    {
       // PopulateMap();
    }

    public void PopulateMap()
    {
        //clear map
        while(transform.childCount>0) DestroyImmediate(transform.GetChild(0).gameObject);

        FreeSpaces.Clear();

        //spawn solidWalls
        for (int x = Bounds.min.x; x <= Bounds.max.x; x++)
        {
            for (int z = Bounds.min.y; z <= Bounds.max.y; z++)
            {
                Debug.DrawRay(new Vector3(x, .5f, z), Vector3.up, Color.red,1);
                if(MapData.Tiles.ContainsKey(new Vector2Int(x, z)))
                {
                    Debug.Log(new Vector2Int(x, z));
                    switch (MapData.Tiles[new Vector2Int(x, z)])
                    {
                        case Tile.SolidBlock:
                            GameObject.Instantiate(_solidBlockPrefab, new Vector3(x, 0, z), Quaternion.Euler(-90f,0,0),transform);
                            break;
                        case Tile.BrickBlock:
                            GameObject.Instantiate(_brickBlockPrefab, new Vector3(x, .5f, z), Quaternion.Euler(0, 0, -90f), transform);
                            break;
                        case Tile.PlayerSpawn:
                            SpawnSockets.Add(new GameObject("Spawn Socket").transform);
                            SpawnSockets[SpawnSockets.Count-1].position = new Vector3(x, .5f, z);
                            break;
                        case Tile.BombPickup:
                            GameObject.Instantiate(_bombPickupPrefab, new Vector3(x, .5f, z), Quaternion.identity, transform);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    FreeSpaces.Add(new Vector2Int(x, z));
                }
                
            }
        }

       

    }

    private void OnDrawGizmosSelected()
    {
        foreach (var s in FreeSpaces) 
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawWireCube(new Vector3(s.x, .5f, s.y),Vector3.one*0.2f);
        }

    }
}



[Serializable]
public struct MapInfo
{
    public Vector2Int Start_Inclusive;
    public Vector2Int End_Exclusive;
    public int BombCount;
    public int BricksCount;
    public float SolidWallsPercentage;
    public int freeSpaces {
        get
        {
            Vector2Int size = End_Exclusive - Start_Inclusive;
            return size.x * size.y * 3 / 4;
        }
    }
}