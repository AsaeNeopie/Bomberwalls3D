using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    [Header("asset references")]
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] GameObject _botPrefab;

    [Header("Scene References")]
    [SerializeField] LevelManager _levelManager;
    

    [HideInInspector] public List<PlayerReference> AlivePlayers;
    


    //singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    private void Start()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        for (int i = 0; i < menuPlayerManager.PlayerCount; i++)
        {
            print(i);
            AlivePlayers.Add(GameObject.Instantiate(_playerPrefab, _levelManager.SpawnSockets[i].position, quaternion.identity).GetComponent<PlayerReference>());
            AlivePlayers[i].OnDead += OnPlayerDied;
        }

        if (menuPlayerManager.BotCount>0) for (int i = 0; i < menuPlayerManager.BotCount; i++)
        {
            GameObject.Instantiate(_botPrefab, _levelManager.SpawnSockets[i + menuPlayerManager.PlayerCount].position,quaternion.identity);
            AlivePlayers[i].OnDead += OnPlayerDied;
        }
    }

    void OnPlayerDied(PlayerReference player)
    {
        AlivePlayers.Remove(player);
        if(AlivePlayers.Count == 1)
        {
            TimeManager.instance.StopTime(.5f);
        }
    }


}
