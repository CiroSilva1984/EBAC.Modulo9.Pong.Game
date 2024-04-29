using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public GameObject screenEndGame;

    public int scorePlayer = 0;
    public int scoreEnemy = 0;

    public TextMeshProUGUI textPointPlayer;
    public TextMeshProUGUI textPointEnemy;
    public TextMeshProUGUI textEndGame;

    public BallController ballController;

    public int winPoints = 3;

    private void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        //Defini as posições iniciais das Raquetes
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);

        ballController.ResetBall();

        scorePlayer = 0;
        scoreEnemy = 0;

        textPointPlayer.text = scorePlayer.ToString();
        textPointEnemy.text = scoreEnemy.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        scorePlayer++;
        textPointPlayer.text = scorePlayer.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        scoreEnemy++;
        textPointEnemy.text = scoreEnemy.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(scoreEnemy >= winPoints || scorePlayer >= winPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
       textEndGame.text = "Vitória " + SaveController.Instance.GetName(scorePlayer > scoreEnemy);

        Invoke("LoadMenu", 2f);

    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("SCN_Menu");
    }
}