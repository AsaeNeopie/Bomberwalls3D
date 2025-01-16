using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPlayerManager : MonoBehaviour
{
    public static int PlayerCount, BotCount;
    public void AddBot(int offset)
    {
        PlayerCount += offset;
        PlayerCount = Mathf.Max(PlayerCount, 0);
    }

    public void AddPlayer(int offset)
    {
        BotCount += offset;
        BotCount = Mathf.Max(BotCount, 0);
    }

    public void LaunchGame()
    {
        if (PlayerCount <= 0) return;
        SceneManager.LoadScene(1);
    }

}
