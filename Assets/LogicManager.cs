using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public float pipeMoveSpeed = 5;
    public bool gameActive = true;
    public GameObject gameOverUi;
    public GameObject startingUi;
    public bool startingState = true;

    [ContextMenu("Increase score")]
    public void addScore(int s)
    {
        score += s;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverUi.SetActive(true);
        gameActive = false;
    }
}
