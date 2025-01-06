using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;

    [SerializeField] TMP_Text _text;
    public bool isReady = false;
    bool justSpawned = true;
    public void OnPlayerJoin(InputAction.CallbackContext context)
    {

        if (context.performed && !justSpawned && GameManager.Instance.PlayerMenuList.Contains(this))
        {
            _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   waiting";

            isReady = true;
                _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   ready";

                bool launchGame = true;
                foreach(PlayerMenu p in GameManager.Instance.PlayerMenuList)
                {
                    launchGame &= p.isReady;
                }
                if(launchGame )
                { 
                    GameManager.Instance.UpdateSpawnPlayerCount();
                    SceneManager.LoadScene("MainMap");
                }
            
        }else if (context.performed && !justSpawned)
        {
            GameManager.Instance.RegisterPlayerInMenu(this);
            _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   waiting";
        }
    }

    private IEnumerator Start()
    {

        transform.parent = GameObject.Find("PlayerMenuParent").transform;
        isReady = false;

        GameManager.Instance.RegisterPlayerInMenu(this);
        _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   waiting";
        yield return null;
        justSpawned = false;
    }
    public void OnPlayerLeave(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isReady)
            {
                if(GameManager.Instance.PlayerMenuList.Contains(this))
                {
                    _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   not playing";
                    GameManager.Instance.PlayerMenuList.Remove(this);
                    isReady = false;
                    bool launchGame = true;
                    foreach (PlayerMenu p in GameManager.Instance.PlayerMenuList)
                    {
                        launchGame &= p.isReady;
                    }
                    if (launchGame)
                    {
                        GameManager.Instance.UpdateSpawnPlayerCount();
                        SceneManager.LoadScene("MainMap");
                    }

                }

            }
            else
            {
                _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   waiting";
                isReady = false;
            }

        }
    }

    public void RemovePlayer(PlayerInput input)
    {
        if(GameManager.Instance.PlayerMenuList.Contains(this))
        {
            isReady = false;
            _text.text = $"Player {GameManager.Instance.PlayerMenuList.IndexOf(this)}   waiting";
        }
    }
}
