using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += TurnOn;
    }

    void TurnOn()
    {
        Debug.Log("putain");
        GetComponent<Animation>().Play();
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
