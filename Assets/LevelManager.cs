using System;
using System.Collections.Generic;
using Unity.Mathematics;
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

    //bouton open map edition window

    private void Start()
    {
        PopulateMap();
    }

    public void PopulateMap()
    {
        //clear map
        for (int i = 0; i < transform.childCount; i++) DestroyImmediate(transform.GetChild(0).gameObject);

        FreeSpaces.Clear();

        //spawn solidWalls
        for (int x = Bounds.min.x; x < Bounds.max.x; x++)
        {
            for (int z = Bounds.min.y; z < Bounds.max.y; z++)
            {

                if (x % 2 == 0 && z % 2 == 0 && UnityEngine.Random.value * 100 <= 80)
                {
                    GameObject.Instantiate(_solidBlockPrefab, new Vector3(x, .5f, z), quaternion.Euler(90*Mathf.Deg2Rad,0,0),transform);
                }
                else
                {
                    FreeSpaces.Add(new Vector2Int(x, z));
                }
            }
        }

        //spawn brick walls
        for (int i = 0; i < 20; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, FreeSpaces.Count);
            GameObject.Instantiate(_brickBlockPrefab, new Vector3(FreeSpaces[RandomIndex].x, .5f, FreeSpaces[RandomIndex].y), quaternion.identity,transform);
            FreeSpaces.RemoveAt(RandomIndex);
        }

        //spawn bomb pick ups
        for (int i = 0; i < 20; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, FreeSpaces.Count);
            GameObject.Instantiate(_bombPickupPrefab, new Vector3(FreeSpaces[RandomIndex].x, .5f, FreeSpaces[RandomIndex].y), quaternion.identity,transform);
            FreeSpaces.RemoveAt(RandomIndex);
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