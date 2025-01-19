using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Vector2Int> FreeSpaces { get; private set; } = new();

    
    public MapInfo Info = new MapInfo()
    {
        Start_Inclusive = new Vector2Int(-15, -1),
        End_Exclusive = new Vector2Int(2, 10),
        BombCount = 10,
        BricksCount = 10,
        SolidWallsPercentage = 80
    };//custom inspector avec bouton "edit" qui ouvre une window comme pour les couleurs


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
        for (int x = Info.Start_Inclusive.x; x < Info.End_Exclusive.x; x++)
        {
            for (int z = Info.Start_Inclusive.y; z < Info.End_Exclusive.y; z++)
            {

                if (x % 2 == 0 && z % 2 == 0 && UnityEngine.Random.value * 100 <= Info.SolidWallsPercentage)
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
        for (int i = 0; i < Info.BricksCount; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, FreeSpaces.Count);
            GameObject.Instantiate(_brickBlockPrefab, new Vector3(FreeSpaces[RandomIndex].x, .5f, FreeSpaces[RandomIndex].y), quaternion.identity,transform);
            FreeSpaces.RemoveAt(RandomIndex);
        }

        //spawn bomb pick ups
        for (int i = 0; i < Info.BombCount; i++)
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