using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { PREPARED, PLAYING, GAMEOVER };
    public GameState state;
    public GameObject player, asteroidSpawner, joystick, button, start;
    public Button startBtn;
    public int lives = 3;
    public Text infoText;
    private Spaceship spaceshipScript;
    private bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.PREPARED;
        spaceshipScript = player.GetComponent<Spaceship>();
        startBtn.onClick.AddListener(StartGame);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameState();
    }

    void UpdateGameState()
    {
        switch (state)
        {
            case GameState.PREPARED:
                infoText.text = "Press Start to play";
                player.SetActive(false);
                asteroidSpawner.SetActive(false);
                joystick.SetActive(false);
                button.SetActive(false);
                start.SetActive(true);

                if (gameStarted)
                {
                    player.SetActive(true);
                    asteroidSpawner.SetActive(true);
                    joystick.SetActive(true);
                    button.SetActive(true);
                    start.SetActive(false);
                    state = GameState.PLAYING;
                }
                break;
            case GameState.PLAYING:
                infoText.text = "Lives: " + lives;
                if (lives <= 0)
                {
                    player.SetActive(false);
                    joystick.SetActive(false);
                    button.SetActive(false);
                    start.SetActive(true);
                    gameStarted = false;
                    state = GameState.GAMEOVER;
                }
                break;
            case GameState.GAMEOVER:
                infoText.text = "GAME OVER! Press start to restart";
                startBtn.onClick.AddListener(StartGame);
                if (gameStarted)
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }

    private void StartGame()
    {
        gameStarted = true;
    }

    public void CallShootBullet()
    {
        if (spaceshipScript != null)
        {
            spaceshipScript.ShootBullet();
        }
        else
        {
            Debug.Log("Spaceship script not found");
        }
    }
}
