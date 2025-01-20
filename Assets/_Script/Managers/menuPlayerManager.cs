using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPlayerManager : MonoBehaviour
{
    public static int PlayerCount, BotCount;
    [SerializeField] TMP_Text _playerCountText, _botCountText;

    public void AddBot(int offset)
    {
        BotCount += offset;
        BotCount = Mathf.Max(BotCount, 0);
        _botCountText.text = "Number of bots : " + BotCount.ToString();
    }

    public void AddPlayer(int offset)
    {
        PlayerCount += offset;
        PlayerCount = Mathf.Max(PlayerCount, 0);
        _playerCountText.text = "Number of players : " + PlayerCount.ToString();
    }

    public void LaunchGame()
    {
        if (PlayerCount <= 0) return;
        SceneManager.LoadScene(1);
    }

}
