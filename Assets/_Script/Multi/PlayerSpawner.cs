using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] List<GameObject> _spawnPoints;


    private void Start()
    {
        Debug.LogWarning(GameManager.SpawnPlayerCount);
        if (GameManager.SpawnPlayerCount == 0) return;

        for(int i = 0; i< GameManager.SpawnPlayerCount; i++)
        {
            SpawnPlayer(i);
        }
    }

    void SpawnPlayer(int i)
    {
        Instantiate(_playerPrefab, _spawnPoints[i%_spawnPoints.Count].transform.position, Quaternion.identity);
    }
}
