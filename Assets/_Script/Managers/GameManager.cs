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
    [SerializeField] private TMP_Text _textBeginnig; 
    //player management
    [HideInInspector] public List<PlayerMenu> PlayerMenuList;
    public static int SpawnPlayerCount;
    
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
        instance = this;
        if(SceneManager.GetActiveScene().buildIndex == 0 ) SpawnPlayerCount = 0;
    }

    public void RegisterPlayerInMenu(PlayerMenu Player)
    {
        PlayerMenuList.Add(Player);
    }


    public void UpdateSpawnPlayerCount()
    {
        int c = 0;
        foreach (PlayerMenu p in PlayerMenuList)
        {
            if (p.isReady) { c++; }
        }
        SpawnPlayerCount = c;
        Debug.LogWarning(SpawnPlayerCount);
    }
}
