using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private PlayerController playerController;
    private PipeSpawner pipeSpawner;
    private bool hasGameStarted = false;

    public bool isGameActive = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startText;
    public GameObject gameOverScreen;

    private void Start()
    {
        playerController = GameObject.Find("Bird").GetComponent<PlayerController>();
        pipeSpawner = GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !hasGameStarted)
        {
            Debug.Log("Start Game");
            hasGameStarted = true;
            StartGame();
        }
    }
    
    private void StartGame()
    {
        isGameActive = true;
        startText.gameObject.SetActive(false);
        playerController.InitializePlayer();
        pipeSpawner.ToggleSpawner();
    }

    public void AddScore(int scoreToAdd)
    {
        score+= scoreToAdd;
        scoreText.SetText(score.ToString());
    }

    public void GameOver()
    {
        isGameActive = false;
        pipeSpawner.ToggleSpawner();
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
