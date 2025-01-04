using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject spawner;

    [Header("UI Elements")] public Canvas startUI;
    public Canvas gameOverUI;
    public Canvas getReadyUI;

    private static int _score;
    private PlayerFlap _playerFlap;
    private bool _gameStarted;
    private FloorMovement _floorMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerFlap = player.GetComponent<PlayerFlap>();
        _floorMovement = GameObject.Find("Floors").GetComponent<FloorMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _score = _playerFlap.score;
        scoreText.text = _score.ToString();

        if (_playerFlap.dead)
        {
            gameOverUI.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            spawner.GetComponent<SpawnBehaviour>().SetSpeed(0);
            _floorMovement.speed = 0;
            spawner.GetComponent<SpawnBehaviour>().timerOn = false;
        }

        if (_playerFlap.started)
        {
            startUI.gameObject.SetActive(false);

            if (!_gameStarted)
            {
                getReadyUI.gameObject.SetActive(true);
                StartCoroutine(DisableGetReady());
            }
        }
        else
        {
            startUI.gameObject.SetActive(true);
            getReadyUI.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
        }
    }

    private IEnumerator DisableGetReady()
    {
        yield return new WaitForSeconds(1.5f);
        getReadyUI.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        _gameStarted = true;
    }

    private IEnumerator RestartGame()
    {
        spawner.GetComponent<SpawnBehaviour>().SetSpeed(0f);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}