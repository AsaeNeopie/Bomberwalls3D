using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<Vector2Int> _freeSpaces = new();

    public struct MapInfo
    {
        public Vector2Int Start_Inclusive;
        public Vector2Int End_Exclusive;
        public int BombCount;
        public int BricksCount;
        public float SolidWallsPercentage;
    }

    //notifier
    public event Action OnMapUpdated;

    [Header("Prefab references")]
    [SerializeField] GameObject _bombPickupPrefab;
    [SerializeField] GameObject _brickBlockPrefab;
    [SerializeField] GameObject _solidBlockPrefab;

    //bouton open map edition window

    void PopulateMap(MapInfo info)
    {
        //clear map
        for(int i = 0; i < transform.childCount;i++) DestroyImmediate(transform.GetChild(0));

        _freeSpaces.Clear();

        //spawn solidWalls
        for(int x = info.Start_Inclusive.x; x < info.End_Exclusive.x; x++)
        {
            for (int z = info.Start_Inclusive.y; z < info.End_Exclusive.y; z++)
            {

                if(x%2==0 && z%2 ==0 && UnityEngine.Random.value * 100 <= info.SolidWallsPercentage)
                {
                    GameObject.Instantiate(_solidBlockPrefab, new Vector3(x, .5f, z), quaternion.identity);
                }
                else
                {
                    _freeSpaces.Add(new Vector2Int(x, z));
                }
            }
        }

        //spawn brick walls
        for (int i = 0; i < info.BricksCount; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, _freeSpaces.Count);
            GameObject.Instantiate(_brickBlockPrefab, new Vector3(_freeSpaces[i].x, .5f, _freeSpaces[i].y), quaternion.identity);
            _freeSpaces.RemoveAt(RandomIndex);
        }

        //spawn bomb pick ups
        for (int i = 0; i < info.BombCount; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, _freeSpaces.Count);
            GameObject.Instantiate(_bombPickupPrefab, new Vector3(_freeSpaces[i].x, .5f, _freeSpaces[i].y), quaternion.identity);
            _freeSpaces.RemoveAt(RandomIndex);
        }


    }


}
