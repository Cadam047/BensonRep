using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get;private set; }


// object animation 

    public float initialGameSpeed = 1f;
    public float gameSpeedIncrease = 0.1f;
    

    public float gameSpeed { get; private set; }

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscore;

    public TextMeshProUGUI highscoreText;

    public Button RetryButton;

    private Player player;
    private Spawner spawner;


    private Vector2 startPlayerPos = new Vector2(-3.268f, -0.988f);

    private float score;

    private void Awake() 

    {

        if (Instance == null) {

            Instance = this;

        } else {

            DestroyImmediate(gameObject);

        }

    }

    private void OnDestroy() 
    {
        if (Instance == this) {

            Instance = null;

        }

    }

    private void Start() 
    {


        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        // Set the initial position for the player
        player.transform.position = startPlayerPos;

        NewGame();

    }

    public void Respawn() {

    // Reset the player's position to the start position

    player.transform.position = startPlayerPos;


    }

    public void NewGame()
    {



        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {

            Destroy(obstacle.gameObject);

        }

        score = 0f;

        player.transform.position = startPlayerPos;

        

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);

        UpdateHighScore();

    }

    public void GameOver() {



        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        RetryButton.gameObject.SetActive(true);

        UpdateHighScore();

    }

    private void Update() 
    {

        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");

    }

    public void UpdateHighScore() {

        float highscore = PlayerPrefs.GetFloat("highscore", 0);

        if (score > highscore) {

            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);


        }

        highscoreText.text = Mathf.FloorToInt(highscore).ToString("D5");


    }


}

